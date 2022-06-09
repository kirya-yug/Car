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
    public class CarOwnersController : Controller
    {
        private TRPKEntities db = new TRPKEntities();

        // GET: CarOwners
        public ActionResult Index()
        {
            return View(db.CarOwner.ToList());
        }

        // GET: CarOwners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOwner carOwner = db.CarOwner.Find(id);
            if (carOwner == null)
            {
                return HttpNotFound();
            }
            return View(carOwner);
        }

        // GET: CarOwners/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarOwners/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,full_name,address,gender,driver_license_no,DOB")] CarOwner carOwner)
        {
            if (ModelState.IsValid)
            {
                db.CarOwner.Add(carOwner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carOwner);
        }

        // GET: CarOwners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOwner carOwner = db.CarOwner.Find(id);
            if (carOwner == null)
            {
                return HttpNotFound();
            }
            return View(carOwner);
        }

        // POST: CarOwners/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,full_name,address,gender,driver_license_no,DOB")] CarOwner carOwner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carOwner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carOwner);
        }

        // GET: CarOwners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOwner carOwner = db.CarOwner.Find(id);
            if (carOwner == null)
            {
                return HttpNotFound();
            }
            return View(carOwner);
        }

        // POST: CarOwners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarOwner carOwner = db.CarOwner.Find(id);
            db.CarOwner.Remove(carOwner);
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
