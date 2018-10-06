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
    public class ProductController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();

        // GET: Product_t
        public ActionResult Index()
        {
            var product_t = db.Product_t.Include(p => p.Category_t).Include(p => p.Unit_t).Include(p => p.Warehouse_t);
            return View(product_t.ToList());
        }

        // GET: Product_t/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_t product_t = db.Product_t.Find(id);
            if (product_t == null)
            {
                return HttpNotFound();
            }
            return View(product_t);
        }

        // GET: Product_t/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.Category_t, "category_id", "name");
            ViewBag.unit_id = new SelectList(db.Unit_t, "unit_id", "description");
            ViewBag.warehouse_id = new SelectList(db.Warehouse_t, "warehouse_id", "name");
            return View();
        }

        // POST: Product_t/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "product_id,name,description,price,existence,unit_id,category_id,warehouse_id,last_update_date,creation_Date,last_user_update")] Product_t product_t)
        {
            if (ModelState.IsValid)
            {
                db.Product_t.Add(product_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.Category_t, "category_id", "name", product_t.category_id);
            ViewBag.unit_id = new SelectList(db.Unit_t, "unit_id", "description", product_t.unit_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouse_t, "warehouse_id", "name", product_t.warehouse_id);
            return View(product_t);
        }

        // GET: Product_t/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_t product_t = db.Product_t.Find(id);
            if (product_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.Category_t, "category_id", "name", product_t.category_id);
            ViewBag.unit_id = new SelectList(db.Unit_t, "unit_id", "description", product_t.unit_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouse_t, "warehouse_id", "name", product_t.warehouse_id);
            return View(product_t);
        }

        // POST: Product_t/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "product_id,name,description,price,existence,unit_id,category_id,warehouse_id,last_update_date,creation_Date,last_user_update")] Product_t product_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.Category_t, "category_id", "name", product_t.category_id);
            ViewBag.unit_id = new SelectList(db.Unit_t, "unit_id", "description", product_t.unit_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouse_t, "warehouse_id", "name", product_t.warehouse_id);
            return View(product_t);
        }

        // GET: Product_t/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product_t product_t = db.Product_t.Find(id);
            if (product_t == null)
            {
                return HttpNotFound();
            }
            return View(product_t);
        }

        // POST: Product_t/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product_t product_t = db.Product_t.Find(id);
            db.Product_t.Remove(product_t);
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
