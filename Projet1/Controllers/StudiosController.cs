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
    public class StudiosController : Controller
    {
        private BdImmobilier db = new BdImmobilier();

        // GET: Studios
        public ActionResult Index()
        {
            var studios = db.studios.Include(s => s.Proprietaire);
            return View(studios.ToList());
        }

        // GET: Studios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = (Studio)db.studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // GET: Studios/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.users, "idUser", "prenom");
            return View();
        }

        // POST: Studios/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idstudio,descriptionstudio,superficiestudio,lacalitestudio,nbrSalleEau,nbrCuisine,nbrToilette,IdProprio,nbrPiece,MaisonId")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.studios.Add(studio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.users, "idUser", "prenom", studio.IdProprio);
            return View(studio);
        }

        // GET: Studios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = (Studio)db.studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.users, "idUser", "prenom", studio.IdProprio);
            return View(studio);
        }

        // POST: Studios/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idstudio,descriptionstudio,superficiestudio,lacalitestudio,nbrSalleEau,nbrCuisine,nbrToilette,IdProprio,nbrPiece,MaisonId")] Studio studio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.users, "idUser", "prenom", studio.IdProprio);
            return View(studio);
        }

        // GET: Studios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studio studio = (Studio)db.studios.Find(id);
            if (studio == null)
            {
                return HttpNotFound();
            }
            return View(studio);
        }

        // POST: Studios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studio studio = (Studio)db.studios.Find(id);
            db.studios.Remove(studio);
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
