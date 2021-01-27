using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TicketingSystem.Models;


namespace TicketingSystem.Controllers
{
    public class ticketsController : Controller
    {
        private databaseModel db = new databaseModel();

        // GET: tickets
        public ActionResult Index()
        {
            var ticket = db.ticket.Include(t => t.customers).Include(t => t.staff).Include(t => t.ticket_categories).Include(t => t.ticket_priorities).Include(t => t.ticket_statuses);
            return View(ticket.ToList());
        }

        // GET: tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: tickets/Create
        public ActionResult Create()
        {
            ViewBag.customer_number = new SelectList(db.customers, "id", "username");
            ViewBag.agent = new SelectList(db.staff, "id", "username");
            ViewBag.category = new SelectList(db.ticket_categories, "id", "name");
            ViewBag.priority = new SelectList(db.ticket_priorities, "id", "name");
            ViewBag.status = new SelectList(db.ticket_statuses, "id", "name");
            return View();
        }

        // POST: tickets/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subject,content,customer,category")] CreateTicket createticket)
        {
            if (ModelState.IsValid)
            {
                string stmt = "[dbo].[sp_createTicket] @subject, @content, @customer, @category";

                SqlParameter suParam = new SqlParameter("@subject", createticket.subject);

                SqlParameter coParam = new SqlParameter("@content", createticket.content);

                SqlParameter cuParam = new SqlParameter("@customer", createticket.customer);

                SqlParameter caParam = new SqlParameter("@category", createticket.category);



                //SqlParameter bestatus = new SqlParameter("@status", benutzeranlage.status);
                //bestatus.Direction = ParameterDirection.Output;
                object[] parameters = { suParam, coParam, cuParam, caParam };

                db.Database.ExecuteSqlCommand(stmt, parameters);

                return RedirectToAction("Index");
            }
           
            return View(createticket);
        }

        public ActionResult SucheEingabe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SucheRückgabe([Bind(Include = "suchbegriff")] Suche suche)

        {

            if (suche == null)
            {
                return HttpNotFound();
            }
            IQueryable<ticket> searchResult = db.ticket.Where(x => x.subject.ToLower().Contains(suche.suchbegriff) 
                                                                || x.ticket_content.ToLower().Contains(suche.suchbegriff)
                                                                                                                );


            return View(searchResult.ToList());

        }


        // GET: tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_number = new SelectList(db.customers, "id", "username", ticket.customer_number);
            ViewBag.agent = new SelectList(db.staff, "id", "username", ticket.agent);
            ViewBag.category = new SelectList(db.ticket_categories, "id", "name", ticket.category);
            ViewBag.priority = new SelectList(db.ticket_priorities, "id", "name", ticket.priority);
            ViewBag.status = new SelectList(db.ticket_statuses, "id", "name", ticket.status);
            return View(ticket);
        }

        // POST: tickets/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,subject,ticket_content,customer_number,agent,status,category,priority,created_at,updated_at,completed_at")] ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_number = new SelectList(db.customers, "id", "username", ticket.customer_number);
            ViewBag.agent = new SelectList(db.staff, "id", "username", ticket.agent);
            ViewBag.category = new SelectList(db.ticket_categories, "id", "name", ticket.category);
            ViewBag.priority = new SelectList(db.ticket_priorities, "id", "name", ticket.priority);
            ViewBag.status = new SelectList(db.ticket_statuses, "id", "name", ticket.status);
            return View(ticket);
        }

        // GET: tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ticket ticket = db.ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ticket ticket = db.ticket.Find(id);
            db.ticket.Remove(ticket);
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
