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
    public class AppartementViewModelsController : Controller
    {
        private BdImmobilier db = new BdImmobilier();

        private List<AppartementViewModel> GetAppartementViewModels()
        {
            List<AppartementViewModel> liste = new List<AppartementViewModel>();
            var listeAppartement = db.appartements.ToList();
            var listeBien = db.biens.ToList();
            foreach (var item in listeAppartement)
            {
                var leBien = listeBien.Where(a => a.IdBien == item.IdBien).FirstOrDefault();
                AppartementViewModel ap = new AppartementViewModel();
                ap.superficieBien = item.superficieBien;
                ap.IdProprio = item.IdProprio;
                ap.nbrCuisine = item.nbrCuisine;
                ap.descriptionBien = item.descriptionBien;
                ap.nbrSalleEau = item.nbrSalleEau;
                ap.nbrToilette = item.nbrToilette;
                ap.lacaliteBien = item.lacaliteBien;
                ap.nbrSalle = item.nbrSalle;

                liste.Add(ap);
            }
            return liste;
        }

        // GET: AppartementViewModels
        public ActionResult Index()
        {
             var appartementViewModels = GetAppartementViewModels();
            return View(appartementViewModels.ToList());
        }

        // GET: AppartementViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppartementViewModel appartementViewModel = null; // db.AppartementViewModels.Find(id);
            if (appartementViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appartementViewModel);
        }

        // GET: AppartementViewModels/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom");
            return View();
        }

        // POST: AppartementViewModels/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,descriptionBien,superficieBien,lacaliteBien,nbrSalleEau,nbrCuisine,nbrToilette,nbrSalle,IdProprio")] AppartementViewModel appartementViewModel)
        {
            if (ModelState.IsValid)
            {
                Appartement ap = new Appartement();
                ap.superficieBien = appartementViewModel.superficieBien;
                ap.nbrCuisine = appartementViewModel.nbrCuisine;
                ap.descriptionBien = appartementViewModel.descriptionBien;
                ap.lacaliteBien = appartementViewModel.lacaliteBien;
                ap.nbrSalleEau = appartementViewModel.nbrSalleEau;
                ap.nbrToilette = appartementViewModel.nbrToilette;
                ap.nbrSalle = appartementViewModel.nbrSalle;
                ap.IdProprio = appartementViewModel.IdProprio;
                db.biens.Add(ap);
                db.SaveChanges();
               
               
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", appartementViewModel.IdProprio);
            return View(appartementViewModel);
        }

        // GET: AppartementViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppartementViewModel appartementViewModel = null; // db.AppartementViewModels.Find(id);
            if (appartementViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", appartementViewModel.IdProprio);
            return View(appartementViewModel);
        }

        // POST: AppartementViewModels/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  Edit([Bind(Include = "IdBien,descriptionBien,superficieBien,lacaliteBien,nbrSalleEau,nbrCuisine,nbrToilette,nbrSalle,IdProprio")] AppartementViewModel appartementViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appartementViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", appartementViewModel.IdProprio);
            return View(appartementViewModel);
        }

        // GET: AppartementViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AppartementViewModel appartementViewModel = null; // db.AppartementViewModels.Find(id);
            if (appartementViewModel == null)
            {
                return HttpNotFound();
            }
            return View(appartementViewModel);
        }

        // POST: AppartementViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            /*AppartementViewModel appartementViewModel = db.AppartementViewModels.Find(id);
            db.AppartementViewModels.Remove(appartementViewModel);*/
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
