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
    public class ObjectsController : Controller
    {
        private BuildingContractorContext db = new BuildingContractorContext();

        // GET: Objects
        public ActionResult Index()
        {
            return View(db.Objects.ToList());
        }

        // GET: Objects/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objects objects = db.Objects.Find(id);
            if (objects == null)
            {
                return HttpNotFound();
            }
            return View(objects);
        }

        // GET: Objects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameObject,Customer,GeneralConstractor,ContractConclusionDate,DeliveryDate,StartUp,Photo")] Objects objects)
        {
            if (ModelState.IsValid)
            {
                objects.ID = Guid.NewGuid();
                db.Objects.Add(objects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(objects);
        }

        // GET: Objects/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objects objects = db.Objects.Find(id);
            if (objects == null)
            {
                return HttpNotFound();
            }
            return View(objects);
        }

        // POST: Objects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameObject,Customer,GeneralConstractor,ContractConclusionDate,DeliveryDate,StartUp,Photo")] Objects objects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(objects);
        }

        // GET: Objects/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objects objects = db.Objects.Find(id);
            if (objects == null)
            {
                return HttpNotFound();
            }
            return View(objects);
        }

        // POST: Objects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Objects objects = db.Objects.Find(id);
            db.Objects.Remove(objects);
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
