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
    public class CategoryController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();

        // GET: Category_t
        public ActionResult Index()
        {
            return View(db.Category_t.ToList());
        }

        // GET: Category_t/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_t category_t = db.Category_t.Find(id);
            if (category_t == null)
            {
                return HttpNotFound();
            }
            return View(category_t);
        }

        // GET: Category_t/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category_t/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "category_id,name,description,last_update_date,creation_Date,last_user_update")] Category_t category_t)
        {
            if (ModelState.IsValid)
            {
                db.Category_t.Add(category_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category_t);
        }

        // GET: Category_t/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_t category_t = db.Category_t.Find(id);
            if (category_t == null)
            {
                return HttpNotFound();
            }
            return View(category_t);
        }

        // POST: Category_t/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "category_id,name,description,last_update_date,creation_Date,last_user_update")] Category_t category_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category_t);
        }

        // GET: Category_t/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_t category_t = db.Category_t.Find(id);
            if (category_t == null)
            {
                return HttpNotFound();
            }
            return View(category_t);
        }

        // POST: Category_t/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_t category_t = db.Category_t.Find(id);
            db.Category_t.Remove(category_t);
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
