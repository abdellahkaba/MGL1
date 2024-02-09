using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projet1.Models;
using PagedList.Mvc;
using PagedList;
using Projet1.Models;

namespace Projet1.Controllers
{
    public class ProprietairesController : Controller
    {
        private BdImmobilier db = new BdImmobilier();
        int pageSize = 2;

        // GET: Proprietaires
        //public ActionResult Index(int? page, string searchTerm)
        //{
        //    ViewBag.searchTerm = searchTerm != null ? searchTerm : "";
        //    page = page.HasValue ? page : 1;
        //    var liste = db.proprietaires.ToList();
        //    return View(liste.ToPagedList((int)page, pageSize));

        //}
        public ActionResult Index(int? page , string nom ,string prenom)
        {
            page = page.HasValue ? page : 1;
            var liste = db.proprietaires.ToList();

            // passer les instructions de recherche
            ViewBag.prenom = prenom;
            ViewBag.nom = nom;
            if (!string.IsNullOrEmpty(prenom))
            {
                liste = liste.Where(a => a.prenom.ToLower().Contains(prenom.ToLower())).ToList();
            }
            if (!string.IsNullOrEmpty(nom))
            {
                liste = liste.Where(a=>a.nom.ToLower().Contains(nom.ToLower())).ToList();
            }
                return View(liste.ToPagedList((int)page, pageSize));
        }

        // GET: Proprietaires/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = (Proprietaire) db.users.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proprietaires/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUser,prenom,nom,login,password")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(proprietaire);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proprietaire);
        }

        // GET: Proprietaires/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = db.proprietaires.Find(id);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUser,prenom,nom,login,password")] Proprietaire proprietaire)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proprietaire).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proprietaire);
        }

        // GET: Proprietaires/Delete/5
        public ActionResult Delete(int? idBien)
        {
            if (idBien == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proprietaire proprietaire = (Proprietaire)db.users.Find(idBien);
            if (proprietaire == null)
            {
                return HttpNotFound();
            }
            return View(proprietaire);
        }

        // POST: Proprietaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idBien)
        {
            Proprietaire proprietaire = (Proprietaire)db.users.Find(idBien);
            db.users.Remove(proprietaire);
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
