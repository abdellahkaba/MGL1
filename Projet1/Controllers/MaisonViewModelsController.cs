using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Projet1.Models;
using PagedList.Mvc;
using Projet1.Models;
using Projet1.App_Start;


namespace Projet1.Controllers
{
    public class MaisonViewModelsController : Controller
    {
        private BdImmobilier db = new BdImmobilier();
        int pageSize = 2;

        public object MsgBox { get; private set; }

        private List<MaisonViewModel> GetMaisonViewModels()
        {
            List<MaisonViewModel> liste = new List<MaisonViewModel>();
            var listeMaison = db.maisons.ToList();
            var listeBien = db.biens.ToList();
            foreach (var item in listeMaison)
            {
                var leBien = listeBien.Where(a => a.IdBien == item.IdBien).FirstOrDefault();
                MaisonViewModel m = new MaisonViewModel();
                m.IdBien = item.IdBien; 
                m.superficieBien = leBien.superficieBien;
                m.IdProprio = item.IdProprio;
                m.nbrChambre = item.nbrChambre;
                m.nbrCuisine = item.nbrCuisine;
                m.descriptionBien = item.descriptionBien;
                m.nbrSalleEau = item.nbrSalleEau;
                m.nbrToilette = item.nbrToilette;
                m.lacaliteBien = item.lacaliteBien;
                liste.Add(m);
            }
            return liste;
        }

        // GET: MaisonViewModels
        public ActionResult Index(int? page, string localiteBien)
        {
            page = page.HasValue ? page : 1;
            var maisonViewModels = GetMaisonViewModels();
            ViewBag.localite = localiteBien;
            if (!string.IsNullOrEmpty(localiteBien))
            {
                maisonViewModels = maisonViewModels.Where(a => a.lacaliteBien.ToLower().Contains(localiteBien.ToLower())).ToList();
            }
            return View(maisonViewModels.ToPagedList((int)page, pageSize));
        }

        //public ActionResult Index(int? page, string searchTerm)
        //{
        //    ViewBag.searchTerm = searchTerm != null ? searchTerm : "";
        //    page = page.HasValue ? page : 1;
        //    var liste = db.proprietaires.ToList();
        //    return View(liste.ToPagedList((int)page, pageSize));

        //}

        // GET: MaisonViewModels/Details/5
        public ActionResult Details(int? idBien)
        {
            if (idBien == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaisonViewModel maisonViewModel = new MaisonViewModel();
            Maison m = db.maisons.Find(idBien);
            maisonViewModel.IdBien = m.IdBien;
            maisonViewModel.superficieBien = m.superficieBien;
            maisonViewModel.IdProprio = m.IdProprio;
            maisonViewModel.nbrChambre = m.nbrChambre;
            maisonViewModel.nbrCuisine = m.nbrCuisine;
            maisonViewModel.descriptionBien = m.descriptionBien;
            maisonViewModel.nbrSalleEau = m.nbrSalleEau;
            maisonViewModel.nbrToilette = m.nbrToilette;
            maisonViewModel.lacaliteBien = m.lacaliteBien;



            if (maisonViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", maisonViewModel.IdProprio);
            return View(maisonViewModel);
        }

        // GET: MaisonViewModels/Create
        public ActionResult Create()
        {

            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom");
            return View();
        }

        // POST: MaisonViewModels/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,descriptionBien,superficieBien,lacaliteBien,nbrSalleEau,nbrCuisine,nbrToilette,IdProprio,nbrChambre")] MaisonViewModel maisonViewModel)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = "Enregistrer tous " ;
                Maison m = new Maison();
                m.superficieBien = maisonViewModel.superficieBien;
                m.nbrCuisine = maisonViewModel.nbrCuisine;
                m.descriptionBien = maisonViewModel.descriptionBien;
                m.lacaliteBien = maisonViewModel.lacaliteBien;
                m.nbrSalleEau = maisonViewModel.nbrSalleEau;
                m.nbrToilette = maisonViewModel.nbrToilette;
                m.nbrChambre = maisonViewModel.nbrChambre;
                m.IdProprio = maisonViewModel.IdProprio;
                db.biens.Add(m);
                db.SaveChanges();
                this.Flash("Enregistrement effectué", FlashLevel.Success);
                return RedirectToAction("Index");
            }

           ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", maisonViewModel.IdProprio);
            return View(maisonViewModel);
        }


        // GET: MaisonViewModels/Edit/5
        public ActionResult Edit(int? idBien)
        {
            if (idBien == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaisonViewModel maisonViewModel = new MaisonViewModel();
            Maison m = db.maisons.Find(idBien);
            maisonViewModel.IdBien = m.IdBien;
            maisonViewModel.superficieBien = m.superficieBien;
            maisonViewModel.IdProprio = m.IdProprio;
            maisonViewModel.nbrChambre = m.nbrChambre;
            maisonViewModel.nbrCuisine = m.nbrCuisine;
            maisonViewModel.descriptionBien = m.descriptionBien;
            maisonViewModel.nbrSalleEau = m.nbrSalleEau;
            maisonViewModel.nbrToilette = m.nbrToilette;
            maisonViewModel.lacaliteBien = m.lacaliteBien;



            if (maisonViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", maisonViewModel.IdProprio);
            return View(maisonViewModel);
        }

        // POST: MaisonViewModels/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBien,descriptionBien,superficieBien,lacaliteBien,nbrSalleEau,nbrCuisine,nbrToilette,IdProprio,nbrChambre")] MaisonViewModel maisonViewModel)
        {
            if (ModelState.IsValid)
            {
                Maison m = new Maison();
                m.IdBien = maisonViewModel.IdBien;
                m.superficieBien = maisonViewModel.superficieBien;
                m.nbrCuisine = maisonViewModel.nbrCuisine;
                m.descriptionBien = maisonViewModel.descriptionBien;
                m.lacaliteBien = maisonViewModel.lacaliteBien;
                m.nbrSalleEau = maisonViewModel.nbrSalleEau;
                m.nbrToilette = maisonViewModel.nbrToilette;
                m.nbrChambre = maisonViewModel.nbrChambre;
                m.IdProprio = maisonViewModel.IdProprio;

                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", maisonViewModel.IdProprio);
            return View(maisonViewModel);
        }

        // GET: MaisonViewModels/Delete/5
        public ActionResult Delete(int? idBien)
        {
            if (idBien == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maison maisons = (Maison) db.biens.Find(idBien);
            // MaisonViewModel maisonViewModel = db.maisonViewModels.Find(idBien);
            if (maisons == null)
            {
                return HttpNotFound();
            }
            return View(maisons);
        }

        // POST: MaisonViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maison maison = (Maison) db.biens.Find(id);
            db.biens.Remove(maison);
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
