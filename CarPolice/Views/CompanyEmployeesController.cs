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
    public class CompanyEmployeesController : Controller
    {
        private TRPKEntities db = new TRPKEntities();

        // GET: CompanyEmployees
        public ActionResult Index()
        {
            return View(db.CompanyEmployee.ToList());
        }

        // GET: CompanyEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmployee companyEmployee = db.CompanyEmployee.Find(id);
            if (companyEmployee == null)
            {
                return HttpNotFound();
            }
            return View(companyEmployee);
        }

        // GET: CompanyEmployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyEmployees/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,login,password,full_name,pass_no")] CompanyEmployee companyEmployee)
        {
            if (ModelState.IsValid)
            {
                db.CompanyEmployee.Add(companyEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyEmployee);
        }

        // GET: CompanyEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmployee companyEmployee = db.CompanyEmployee.Find(id);
            if (companyEmployee == null)
            {
                return HttpNotFound();
            }
            return View(companyEmployee);
        }

        // POST: CompanyEmployees/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,login,password,full_name,pass_no")] CompanyEmployee companyEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyEmployee);
        }

        // GET: CompanyEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyEmployee companyEmployee = db.CompanyEmployee.Find(id);
            if (companyEmployee == null)
            {
                return HttpNotFound();
            }
            return View(companyEmployee);
        }

        // POST: CompanyEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyEmployee companyEmployee = db.CompanyEmployee.Find(id);
            db.CompanyEmployee.Remove(companyEmployee);
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
