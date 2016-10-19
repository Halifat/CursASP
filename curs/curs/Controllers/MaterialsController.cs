using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using curs.Models;

namespace curs.Controllers
{
    public class MaterialsController : Controller
    {
        private BuildingContractorContext db = new BuildingContractorContext();

        // GET: Materials
        public ActionResult Index()
        {
            var materials = db.Materials.Include(m => m.Objects).Include(m => m.Stock);
            return View(materials.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return HttpNotFound();
            }
            return View(materials);
        }

        // GET: Materials/Create
        public ActionResult Create()
        {
            ViewBag.ObjectsID = new SelectList(db.Objects, "ID", "NameObject");
            ViewBag.StockID = new SelectList(db.Stock, "ID", "NameMaterial");
            return View();
        }

        // POST: Materials/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ObjectsID,StockID")] Materials materials)
        {
            if (ModelState.IsValid)
            {
                materials.ID = Guid.NewGuid();
                db.Materials.Add(materials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObjectsID = new SelectList(db.Objects, "ID", "NameObject", materials.ObjectsID);
            ViewBag.StockID = new SelectList(db.Stock, "ID", "NameMaterial", materials.StockID);
            return View(materials);
        }

        // GET: Materials/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjectsID = new SelectList(db.Objects, "ID", "NameObject", materials.ObjectsID);
            ViewBag.StockID = new SelectList(db.Stock, "ID", "NameMaterial", materials.StockID);
            return View(materials);
        }

        // POST: Materials/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ObjectsID,StockID")] Materials materials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObjectsID = new SelectList(db.Objects, "ID", "NameObject", materials.ObjectsID);
            ViewBag.StockID = new SelectList(db.Stock, "ID", "NameMaterial", materials.StockID);
            return View(materials);
        }

        // GET: Materials/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return HttpNotFound();
            }
            return View(materials);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Materials materials = db.Materials.Find(id);
            db.Materials.Remove(materials);
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
