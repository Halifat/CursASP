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
    public class WorksController : Controller
    {
        private BuildingContractorContext db = new BuildingContractorContext();

        // GET: Works
        public ActionResult Index()
        {
            var works = db.Works.Include(w => w.KindWork).Include(w => w.Objects);
            return View(works.ToList());
        }

        // GET: Works/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            return View(works);
        }

        // GET: Works/Create
        public ActionResult Create()
        {
            ViewBag.KindWorkID = new SelectList(db.KindWork, "ID", "ID");
            ViewBag.ObjectsID = new SelectList(db.Objects, "ID", "NameObject");
            return View();
        }

        // POST: Works/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,KindWorkID,ObjectsID")] Works works)
        {
            if (ModelState.IsValid)
            {
                works.ID = Guid.NewGuid();
                db.Works.Add(works);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KindWorkID = new SelectList(db.KindWork, "ID", "ID", works.KindWorkID);
            ViewBag.ObjectsID = new SelectList(db.Objects, "ID", "NameObject", works.ObjectsID);
            return View(works);
        }

        // GET: Works/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            ViewBag.KindWorkID = new SelectList(db.KindWork, "ID", "ID", works.KindWorkID);
            ViewBag.ObjectsID = new SelectList(db.Objects, "ID", "NameObject", works.ObjectsID);
            return View(works);
        }

        // POST: Works/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,KindWorkID,ObjectsID")] Works works)
        {
            if (ModelState.IsValid)
            {
                db.Entry(works).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KindWorkID = new SelectList(db.KindWork, "ID", "ID", works.KindWorkID);
            ViewBag.ObjectsID = new SelectList(db.Objects, "ID", "NameObject", works.ObjectsID);
            return View(works);
        }

        // GET: Works/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            return View(works);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Works works = db.Works.Find(id);
            db.Works.Remove(works);
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
