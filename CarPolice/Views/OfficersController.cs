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
    public class OfficersController : Controller
    {
        private TRPKEntities db = new TRPKEntities();

        // GET: Officers
        public ActionResult Index()
        {
            return View(db.Officer.ToList());
        }

        // GET: Officers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officer officer = db.Officer.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        // GET: Officers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Officers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,login,password,full_name,rank,position")] Officer officer)
        {
            if (ModelState.IsValid)
            {
                db.Officer.Add(officer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officer);
        }

        // GET: Officers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officer officer = db.Officer.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        // POST: Officers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,login,password,full_name,rank,position")] Officer officer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(officer);
        }

        // GET: Officers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officer officer = db.Officer.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        // POST: Officers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Officer officer = db.Officer.Find(id);
            db.Officer.Remove(officer);
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
