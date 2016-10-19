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
    public class KindWorksController : Controller
    {
        private BuildingContractorContext db = new BuildingContractorContext();

        // GET: KindWorks
        public ActionResult Index()
        {
            return View(db.KindWork.ToList());
        }

        // GET: KindWorks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KindWork kindWork = db.KindWork.Find(id);
            if (kindWork == null)
            {
                return HttpNotFound();
            }
            return View(kindWork);
        }

        // GET: KindWorks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KindWorks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumberLicense,DateLicense,ExpirationLicense,PriceWork,Discount,Tax")] KindWork kindWork)
        {
            if (ModelState.IsValid)
            {
                kindWork.ID = Guid.NewGuid();
                db.KindWork.Add(kindWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kindWork);
        }

        // GET: KindWorks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KindWork kindWork = db.KindWork.Find(id);
            if (kindWork == null)
            {
                return HttpNotFound();
            }
            return View(kindWork);
        }

        // POST: KindWorks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumberLicense,DateLicense,ExpirationLicense,PriceWork,Discount,Tax")] KindWork kindWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kindWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kindWork);
        }

        // GET: KindWorks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KindWork kindWork = db.KindWork.Find(id);
            if (kindWork == null)
            {
                return HttpNotFound();
            }
            return View(kindWork);
        }

        // POST: KindWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            KindWork kindWork = db.KindWork.Find(id);
            db.KindWork.Remove(kindWork);
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
