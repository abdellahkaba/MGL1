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
    public class TerrainViewModelsController : Controller
    {
        private BdImmobilier db = new BdImmobilier();

        private List<TerrainViewModel> GetTerrainViewModels()
        {
            List<TerrainViewModel> liste = new List<TerrainViewModel>();
            var listTerrain = db.terrains.ToList();
            var listeBien = db.biens.ToList();
            foreach (var item in listTerrain)
            {
                var leBien = listeBien.Where(a => a.IdBien == item.IdBien).FirstOrDefault();
                TerrainViewModel tr = new TerrainViewModel();
                tr.typeTerrain = item.typeTerrain;
                tr.superficieBien = item.superficieBien;
                tr.IdProprio = item.IdProprio;
                tr.descriptionBien = item.descriptionBien;
                tr.lacaliteBien = item.lacaliteBien;
                tr.IdProprio = item.IdProprio;

                liste.Add(tr);
            }
            return liste;
        }

        // GET: TerrainViewModels
        public ActionResult Index()
        {
            var terrainViewModels = GetTerrainViewModels();
            return View(terrainViewModels.ToList());
        }

        // GET: TerrainViewModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerrainViewModel terrainViewModel = null; // db.TerrainViewModels.Find(id);
            if (terrainViewModel == null)
            {
                return HttpNotFound();
            }
            return View(terrainViewModel);
        }

        // GET: TerrainViewModels/Create
        public ActionResult Create()
        {
            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom");
            return View();
        }

        // POST: TerrainViewModels/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBien,typeTerrain,descriptionBien,superficieBien,lacaliteBien,IdProprio")] TerrainViewModel terrainViewModel)
        {
            if (ModelState.IsValid)
            {
                Terrain tr = new Terrain();
                tr.typeTerrain = terrainViewModel.typeTerrain;
                tr.superficieBien = terrainViewModel.superficieBien;
                tr.descriptionBien = terrainViewModel.descriptionBien;
                tr.lacaliteBien = terrainViewModel.lacaliteBien;
                tr.IdProprio = terrainViewModel.IdProprio;
                db.biens.Add(tr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", terrainViewModel.IdProprio);
            return View(terrainViewModel);
        }

        // GET: TerrainViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerrainViewModel terrainViewModel = null; // db.TerrainViewModels.Find(id);
            if (terrainViewModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", terrainViewModel.IdProprio);
            return View(terrainViewModel);
        }

        // POST: TerrainViewModels/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  Edit([Bind(Include = "IdBien,typeTerrain,descriptionBien,superficieBien,lacaliteBien,IdProprio")] TerrainViewModel terrainViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terrainViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdProprio = new SelectList(db.proprietaires, "idUser", "prenom", terrainViewModel.IdProprio);
            return View(terrainViewModel);
        }

        // GET: TerrainViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TerrainViewModel terrainViewModel = null; // db.TerrainViewModels.Find(id);
            if (terrainViewModel == null)
            {
                return HttpNotFound();
            }
            return View(terrainViewModel);
        }

        // POST: TerrainViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TerrainViewModel terrainViewModel = null; // db.TerrainViewModels.Find(id);
            /*db.TerrainViewModels.Remove(terrainViewModel);
            db.SaveChanges();*/
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
