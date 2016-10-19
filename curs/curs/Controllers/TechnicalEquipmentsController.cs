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
    public class TechnicalEquipmentsController : Controller
    {
        private BuildingContractorContext db = new BuildingContractorContext();

        // GET: TechnicalEquipments
        public ActionResult Index(string name)
        {
            IQueryable<TechnicalEquipment> tech = db.TechnicalEquipment.Include(p => p.NameTech);
            if (!String.IsNullOrEmpty(name) && !name.Equals("Все"))
            {
                tech = tech.Where(p => p.NameTech == name);
            }

            List<string> teams = db.TechnicalEquipment.Select(n => n.NameTech).ToList();
            // устанавливаем начальный элемент, который позволит выбрать всех
            /* teams.Insert(0, new Team { Name = "Все", Id = 0 });*/

            Filtration filter = new Filtration
            {
                Tech = tech.ToList(),
                Names = new SelectList(teams)
            };

            return View(filter);
        }
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalEquipment technicalEquipment = db.TechnicalEquipment.Find(id);
            if (technicalEquipment == null)
            {
                return HttpNotFound();
            }
            return View(technicalEquipment);
        }

        // GET: TechnicalEquipments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicalEquipments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NameTech,UseTech,DatePurchase,Exploitation")] TechnicalEquipment technicalEquipment)
        {
            if (ModelState.IsValid)
            {
                technicalEquipment.ID = Guid.NewGuid();
                db.TechnicalEquipment.Add(technicalEquipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technicalEquipment);
        }

        // GET: TechnicalEquipments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalEquipment technicalEquipment = db.TechnicalEquipment.Find(id);
            if (technicalEquipment == null)
            {
                return HttpNotFound();
            }
            return View(technicalEquipment);
        }

        // POST: TechnicalEquipments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameTech,UseTech,DatePurchase,Exploitation")] TechnicalEquipment technicalEquipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technicalEquipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technicalEquipment);
        }

        // GET: TechnicalEquipments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalEquipment technicalEquipment = db.TechnicalEquipment.Find(id);
            if (technicalEquipment == null)
            {
                return HttpNotFound();
            }
            return View(technicalEquipment);
        }

        // POST: TechnicalEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TechnicalEquipment technicalEquipment = db.TechnicalEquipment.Find(id);
            db.TechnicalEquipment.Remove(technicalEquipment);
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
