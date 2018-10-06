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
    public class WarehouseController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();

        // GET: Warehouse
        public ActionResult Index()
        {
            return View(db.Warehouse_t.ToList());
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse_t warehouse_t = db.Warehouse_t.Find(id);
            if (warehouse_t == null)
            {
                return HttpNotFound();
            }
            return View(warehouse_t);
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "warehouse_id,name,address,last_update_date,creation_Date,last_user_update")] Warehouse_t warehouse_t)
        {
            if (ModelState.IsValid)
            {
                db.Warehouse_t.Add(warehouse_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouse_t);
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse_t warehouse_t = db.Warehouse_t.Find(id);
            if (warehouse_t == null)
            {
                return HttpNotFound();
            }
            return View(warehouse_t);
        }

        // POST: Warehouse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "warehouse_id,name,address,last_update_date,creation_Date,last_user_update")] Warehouse_t warehouse_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouse_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouse_t);
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Warehouse_t warehouse_t = db.Warehouse_t.Find(id);
            if (warehouse_t == null)
            {
                return HttpNotFound();
            }
            return View(warehouse_t);
        }

        // POST: Warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Warehouse_t warehouse_t = db.Warehouse_t.Find(id);
            db.Warehouse_t.Remove(warehouse_t);
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
