using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketingSystem.Models;

namespace TicketingSystem.Controllers
{
    public class staffsController : Controller
    {
        private databaseModel db = new databaseModel();

        // GET: staffs
        public ActionResult Index()
        {
            var staff = db.staff.Include(s => s.addresses).Include(s => s.salutations);
            return View(staff.ToList());
        }

        // GET: staffs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // GET: staffs/Create
        public ActionResult Create()
        {
            ViewBag.address = new SelectList(db.addresses, "id", "streetname");
            ViewBag.salutation = new SelectList(db.salutations, "id", "name");
            return View();
        }

        // POST: staffs/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,passwordhash,ticket_queue,finished_tickets,lastname,firstname,email,phone,last_login,created_at,failed_logins,address,salutation,absence_begin,absence_end")] staff staff)
        {
            if (ModelState.IsValid)
            {
                db.staff.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.address = new SelectList(db.addresses, "id", "streetname", staff.address);
            ViewBag.salutation = new SelectList(db.salutations, "id", "name", staff.salutation);
            return View(staff);
        }

        // GET: staffs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.address = new SelectList(db.addresses, "id", "streetname", staff.address);
            ViewBag.salutation = new SelectList(db.salutations, "id", "name", staff.salutation);
            return View(staff);
        }

        // POST: staffs/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,username,passwordhash,ticket_queue,finished_tickets,lastname,firstname,email,phone,last_login,created_at,failed_logins,address,salutation,absence_begin,absence_end")] staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.address = new SelectList(db.addresses, "id", "streetname", staff.address);
            ViewBag.salutation = new SelectList(db.salutations, "id", "name", staff.salutation);
            return View(staff);
        }

        // GET: staffs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            staff staff = db.staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View(staff);
        }

        // POST: staffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            staff staff = db.staff.Find(id);
            db.staff.Remove(staff);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
