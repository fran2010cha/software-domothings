using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdomoThingsProyect.Models;

namespace IdomoThingsProyect.Controllers
{
    public class HubsController : Controller
    {
        private IdomoThingsProyectContext db = new IdomoThingsProyectContext();

        // GET: Hubs
        public ActionResult Index()
        {
            return View(db.Hubs.ToList());
        }
        public ActionResult Indexlist()
        {
            return View(db.Hubs.ToList());
        }

        // GET: Hubs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hubs hubs = db.Hubs.Find(id);
            if (hubs == null)
            {
                return HttpNotFound();
            }
            return View(hubs);
        }

        // GET: Hubs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HubsID,Estado")] Hubs hubs)
        {
            if (ModelState.IsValid)
            {
                db.Hubs.Add(hubs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hubs);
        }

        // GET: Hubs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hubs hubs = db.Hubs.Find(id);
            if (hubs == null)
            {
                return HttpNotFound();
            }
            return View(hubs);
        }

        // POST: Hubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HubsID,Estado")] Hubs hubs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hubs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hubs);
        }

        // GET: Hubs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hubs hubs = db.Hubs.Find(id);
            if (hubs == null)
            {
                return HttpNotFound();
            }
            return View(hubs);
        }

        // POST: Hubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Hubs hubs = db.Hubs.Find(id);
            db.Hubs.Remove(hubs);
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
