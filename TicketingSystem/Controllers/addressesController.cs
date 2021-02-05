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
    public class addressesController : Controller
    {
        private databaseModel db = new databaseModel();


        public ActionResult Index()

        {
            // LINQ join
            var addresses = (from a in db.addresses

                             join c in db.countries on a.country equals c.iso

                          

                      select (new

                      {

                          id = a.id,

                          streetname = a.streetname,
                         
                          postalcode = a.postalcode,

                          cityname = a.cityname,

                          country = c.name

                      })).ToList();


            // neue leere Liste

            List<addresses> list = new List<addresses>();

            addresses tempObj;


            // eine Schleife, damit jeder Datensatz in eine neue Liste geschrieben wird

            foreach (var a in addresses)

            {

                // neue Instanz

                tempObj = new addresses();

                // Werte setzen

                tempObj.id = a.id;

                tempObj.streetname = a.streetname;

                tempObj.postalcode = a.postalcode;

                tempObj.cityname = a.cityname;

                tempObj.country = a.country;

                list.Add(tempObj);

            }

            // Liste zurückgeben

            return View(list);

}

// GET: addresses/Details/5
public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addresses addresses = db.addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // GET: addresses/Create
        public ActionResult Create()
        {
            ViewBag.country = new SelectList(db.countries, "iso", "name");
            return View();
        }

        // POST: addresses/Create
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,streetname,postalcode,cityname,country")] addresses addresses)
        {
            if (ModelState.IsValid)
            {
                db.addresses.Add(addresses);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.country = new SelectList(db.countries, "iso", "name", addresses.country);
            return View(addresses);
        }

        // GET: addresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addresses addresses = db.addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            ViewBag.country = new SelectList(db.countries, "iso", "name", addresses.country);
            return View(addresses);
        }

        // POST: addresses/Edit/5
        // Aktivieren Sie zum Schutz vor Angriffen durch Overposting die jeweiligen Eigenschaften, mit denen eine Bindung erfolgen soll. 
        // Weitere Informationen finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,streetname,postalcode,cityname,country")] addresses addresses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addresses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.country = new SelectList(db.countries, "iso", "name", addresses.country);
            return View(addresses);
        }

        // GET: addresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            addresses addresses = db.addresses.Find(id);
            if (addresses == null)
            {
                return HttpNotFound();
            }
            return View(addresses);
        }

        // POST: addresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            addresses addresses = db.addresses.Find(id);
            db.addresses.Remove(addresses);
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
