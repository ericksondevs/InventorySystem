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
    public class RoleController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();

        // GET: Role
        public ActionResult Index()
        {
            return View(db.Role_t.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role_t role_t = db.Role_t.Find(id);
            if (role_t == null)
            {
                return HttpNotFound();
            }
            return View(role_t);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "role_id,description,last_update_date,creation_Date,last_user_update")] Role_t role_t)
        {
            if (ModelState.IsValid)
            {
                role_t.creation_Date = DateTime.Now;
                role_t.last_user_update = User.Identity.Name;
                db.Role_t.Add(role_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role_t);
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role_t role_t = db.Role_t.Find(id);
            if (role_t == null)
            {
                return HttpNotFound();
            }
            return View(role_t);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "role_id,description")] Role_t role_t)
        {
            if (ModelState.IsValid)
            {
                role_t.last_update_date = DateTime.Now;
                role_t.last_user_update = User.Identity.Name;
                db.Entry(role_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role_t);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role_t role_t = db.Role_t.Find(id);
            if (role_t == null)
            {
                return HttpNotFound();
            }
            return View(role_t);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role_t role_t = db.Role_t.Find(id);
            db.Role_t.Remove(role_t);
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
