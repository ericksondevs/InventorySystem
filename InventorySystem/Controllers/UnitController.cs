using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventorySystem.DataBase;

namespace InventorySystem.Controllers
{
    public class UnitController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();

        // GET: Unit
        public ActionResult Index()
        {
            return View(db.Unit_t.ToList());
        }

        // GET: Unit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_t unit_t = db.Unit_t.Find(id);
            if (unit_t == null)
            {
                return HttpNotFound();
            }
            return View(unit_t);
        }

        // GET: Unit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "unit_id,description,last_update_date,creation_Date,last_user_update")] Unit_t unit_t)
        {
            if (ModelState.IsValid)
            {
                db.Unit_t.Add(unit_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unit_t);
        }

        // GET: Unit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_t unit_t = db.Unit_t.Find(id);
            if (unit_t == null)
            {
                return HttpNotFound();
            }
            return View(unit_t);
        }

        // POST: Unit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "unit_id,description,last_update_date,creation_Date,last_user_update")] Unit_t unit_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unit_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unit_t);
        }

        // GET: Unit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Unit_t unit_t = db.Unit_t.Find(id);
            if (unit_t == null)
            {
                return HttpNotFound();
            }
            return View(unit_t);
        }

        // POST: Unit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Unit_t unit_t = db.Unit_t.Find(id);
            db.Unit_t.Remove(unit_t);
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
