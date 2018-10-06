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
    public class UserController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();

        // GET: User
        public ActionResult Index()
        {
            var user_t = db.User_t.Include(u => u.Role_t);
            return View(user_t.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_t user_t = db.User_t.Find(id);
            if (user_t == null)
            {
                return HttpNotFound();
            }
            return View(user_t);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.role_id = new SelectList(db.Role_t, "role_id", "description");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,email,password,role_id,last_update_date,creation_Date,last_user_update")] User_t user_t)
        {
            if (ModelState.IsValid)
            {
                user_t.creation_Date = DateTime.Now;
                user_t.last_user_update = User.Identity.Name;
                db.User_t.Add(user_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.role_id = new SelectList(db.Role_t, "role_id", "description", user_t.role_id);
            return View(user_t);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_t user_t = db.User_t.Find(id);
            if (user_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.role_id = new SelectList(db.Role_t, "role_id", "description", user_t.role_id);
            return View(user_t);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "user_id,email,password,role_id")] User_t user_t)
        {
            if (ModelState.IsValid)
            {
                user_t.last_update_date = DateTime.Now;
                user_t.last_user_update = User.Identity.Name;
                db.Entry(user_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.role_id = new SelectList(db.Role_t, "role_id", "description", user_t.role_id);
            return View(user_t);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_t user_t = db.User_t.Find(id);
            if (user_t == null)
            {
                return HttpNotFound();
            }
            return View(user_t);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_t user_t = db.User_t.Find(id);
            db.User_t.Remove(user_t);
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
