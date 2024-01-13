using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet1.Models;

namespace Projet1.Controllers
{
    public class MaisonsController : Controller
    {
        private BdImmobilier db = new BdImmobilier();

        // GET: Maisons
        public ActionResult Index()
        {
            var maisons = db.maisons.Include(m => m.Proprietaire);
            return View(maisons.ToList());
        }

        // GET: Maisons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maison = (Maison)db.maisons.Find(id);
            if (maison == null)
            {
                return HttpNotFound();
            }
            return View(maison);
        }

        // POST: Maisons/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.users, "idUser", "prenom");
            return View();
        }

        // POST: Maisons/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idmaison,descriptionmaison,superficiemaison,lacalitemaison,nbrSalleEau,nbrCuisine,nbrToilette,IdProprio,nbrChambre")] Maison maison)
        {
            if (ModelState.IsValid)
            {
                db.maisons.Add(maison);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.users, "idUser", "prenom", maison.IdProprio);
            return View(maison);
        }

        // GET: Maisons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maison = (Maison)db.maisons.Find(id);
            if (maison == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.users, "idUser", "prenom", maison.IdProprio);
            return View(maison);
        }

        // POST: Maisons/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idmaison,descriptionmaison,superficiemaison,lacalitemaison,nbrSalleEau,nbrCuisine,nbrToilette,IdProprio,nbrChambre")] Maison maison)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maison).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.users, "idUser", "prenom", maison.IdProprio);
            return View(maison);
        }

        // GET: Maisons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maison = (Maison)db.maisons.Find(id);
            if (maison == null)
            {
                return HttpNotFound();
            }
            return View(maison);
        }

        // POST: Maisons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maison maison = (Maison)db.maisons.Find(id);
            db.maisons.Remove(maison);
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
