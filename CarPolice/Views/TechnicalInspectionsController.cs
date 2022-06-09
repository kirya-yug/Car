using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarPolice.Models;

namespace CarPolice.Views
{
    public class TechnicalInspectionsController : Controller
    {
        private TRPKEntities db = new TRPKEntities();

        // GET: TechnicalInspections
        public ActionResult Index()
        {
            return View(db.TechnicalInspection.ToList());
        }

        // GET: TechnicalInspections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalInspection technicalInspection = db.TechnicalInspection.Find(id);
            if (technicalInspection == null)
            {
                return HttpNotFound();
            }
            return View(technicalInspection);
        }

        // GET: TechnicalInspections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicalInspections/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,conclusion,Date")] TechnicalInspection technicalInspection)
        {
            if (ModelState.IsValid)
            {
                db.TechnicalInspection.Add(technicalInspection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technicalInspection);
        }

        // GET: TechnicalInspections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalInspection technicalInspection = db.TechnicalInspection.Find(id);
            if (technicalInspection == null)
            {
                return HttpNotFound();
            }
            return View(technicalInspection);
        }

        // POST: TechnicalInspections/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,conclusion,Date")] TechnicalInspection technicalInspection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(technicalInspection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(technicalInspection);
        }

        // GET: TechnicalInspections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalInspection technicalInspection = db.TechnicalInspection.Find(id);
            if (technicalInspection == null)
            {
                return HttpNotFound();
            }
            return View(technicalInspection);
        }

        // POST: TechnicalInspections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnicalInspection technicalInspection = db.TechnicalInspection.Find(id);
            db.TechnicalInspection.Remove(technicalInspection);
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
