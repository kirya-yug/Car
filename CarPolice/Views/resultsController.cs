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
    public class resultsController : Controller
    {
        private TRPKEntities db = new TRPKEntities();

        // GET: results
        public ActionResult Index()
        {
            var results = db.results.Include(r => r.Car).Include(r => r.CarOwner).Include(r => r.CompanyEmployee).Include(r => r.Officer).Include(r => r.TechnicalInspection);
            return View(results.ToList());
        }

        // GET: results/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            results results = db.results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // GET: results/Create
        public ActionResult Create()
        {
            ViewBag.id_car = new SelectList(db.Car, "id", "body_no");
            ViewBag.id_owner = new SelectList(db.CarOwner, "id", "full_name");
            ViewBag.id_employee = new SelectList(db.CompanyEmployee, "id", "login");
            ViewBag.id_officer = new SelectList(db.Officer, "id", "login");
            ViewBag.id_inspection = new SelectList(db.TechnicalInspection, "id", "id");
            return View();
        }

        // POST: results/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_car,id_officer,id_employee,id_owner,id_inspection")] results results)
        {
            if (ModelState.IsValid)
            {
                db.results.Add(results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_car = new SelectList(db.Car, "id", "body_no", results.id_car);
            ViewBag.id_owner = new SelectList(db.CarOwner, "id", "full_name", results.id_owner);
            ViewBag.id_employee = new SelectList(db.CompanyEmployee, "id", "login", results.id_employee);
            ViewBag.id_officer = new SelectList(db.Officer, "id", "login", results.id_officer);
            ViewBag.id_inspection = new SelectList(db.TechnicalInspection, "id", "id", results.id_inspection);
            return View(results);
        }

        // GET: results/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            results results = db.results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_car = new SelectList(db.Car, "id", "body_no", results.id_car);
            ViewBag.id_owner = new SelectList(db.CarOwner, "id", "full_name", results.id_owner);
            ViewBag.id_employee = new SelectList(db.CompanyEmployee, "id", "login", results.id_employee);
            ViewBag.id_officer = new SelectList(db.Officer, "id", "login", results.id_officer);
            ViewBag.id_inspection = new SelectList(db.TechnicalInspection, "id", "id", results.id_inspection);
            return View(results);
        }

        // POST: results/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_car,id_officer,id_employee,id_owner,id_inspection")] results results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_car = new SelectList(db.Car, "id", "body_no", results.id_car);
            ViewBag.id_owner = new SelectList(db.CarOwner, "id", "full_name", results.id_owner);
            ViewBag.id_employee = new SelectList(db.CompanyEmployee, "id", "login", results.id_employee);
            ViewBag.id_officer = new SelectList(db.Officer, "id", "login", results.id_officer);
            ViewBag.id_inspection = new SelectList(db.TechnicalInspection, "id", "id", results.id_inspection);
            return View(results);
        }

        // GET: results/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            results results = db.results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // POST: results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            results results = db.results.Find(id);
            db.results.Remove(results);
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
