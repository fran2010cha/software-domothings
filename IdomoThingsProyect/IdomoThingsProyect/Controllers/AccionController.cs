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
    public class AccionController : Controller
    {
        private IdomoThingsProyectContext db = new IdomoThingsProyectContext();

        // GET: Accion
        public ActionResult Index()
        {
            var accions = db.Accions.Include(a => a.hubs).Include(a => a.usuario);
            return View(accions.ToList());
        }
        public ActionResult Indexlist()
        {
            var accions = db.Accions.Include(a => a.hubs).Include(a => a.usuario);
            return View(accions.ToList());
        }

        // GET: Accion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accion accion = db.Accions.Find(id);
            if (accion == null)
            {
                return HttpNotFound();
            }
            return View(accion);
        }

        // GET: Accion/Create
        public ActionResult Create()
        {
            ViewBag.HubsID = new SelectList(db.Hubs, "HubsID", "HubsID");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioID", "Nombre");
            return View();
        }

        // POST: Accion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccionID,AccionHecha,UsuarioId,HubsID")] Accion accion)
        {
            if (ModelState.IsValid)
            {
                db.Accions.Add(accion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HubsID = new SelectList(db.Hubs, "HubsID", "Estado", accion.HubsID);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioID", "Nombre", accion.UsuarioId);
            return View(accion);
        }

        // GET: Accion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accion accion = db.Accions.Find(id);
            if (accion == null)
            {
                return HttpNotFound();
            }
            ViewBag.HubsID = new SelectList(db.Hubs, "HubsID", "Estado", accion.HubsID);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioID", "Nombre", accion.UsuarioId);
            return View(accion);
        }

        // POST: Accion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccionID,AccionHecha,UsuarioId,HubsID")] Accion accion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HubsID = new SelectList(db.Hubs, "HubsID", "Estado", accion.HubsID);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioID", "Nombre", accion.UsuarioId);
            return View(accion);
        }

        // GET: Accion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accion accion = db.Accions.Find(id);
            if (accion == null)
            {
                return HttpNotFound();
            }
            return View(accion);
        }

        // POST: Accion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accion accion = db.Accions.Find(id);
            db.Accions.Remove(accion);
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
