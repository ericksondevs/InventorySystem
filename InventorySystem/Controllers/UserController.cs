using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventorySystem.DataBase;
using InventorySystemRepository;

namespace InventorySystem.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        // GET: User
        public ActionResult Index(string SearchText)
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var result = unit.dbContext.User_t.Include(u => u.Role_t).ToList().Where(s => s.email.Contains(SearchText));

                return View(result.ToList());
            }
            return View(unit.dbContext.User_t.Include(u => u.Role_t).ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_t user_t = unit.UserRepository.Get(x => x.user_id == id);
            if (user_t == null)
            {
                return HttpNotFound();
            }
            return View(user_t);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            ViewBag.role_id = new SelectList(unit.dbContext.Role_t, "role_id", "description");
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user_id,email,password,role_id")] User_t user_t)
        {
            if (ModelState.IsValid)
            {
                unit.UserRepository.Add(user_t);
                unit.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.role_id = new SelectList(unit.dbContext.Role_t, "role_id", "description", user_t.role_id);
            return View(user_t);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_t user_t = unit.UserRepository.Get(x => x.user_id == id);
            if (user_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.role_id = new SelectList(unit.dbContext.Role_t, "role_id", "description", user_t.role_id);
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
                User_t dbuser = unit.UserRepository.Get(x=>x.user_id == user_t.user_id);
                dbuser.email = user_t.email;
                dbuser.password = user_t.password;

                unit.UserRepository.Update(dbuser);
                unit.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.role_id = new SelectList(unit.dbContext.Role_t, "role_id", "description", user_t.role_id);
            return View(user_t);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_t user_t = unit.UserRepository.Get(x => x.user_id == id);
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
            User_t user_t = unit.UserRepository.Get(x => x.user_id == id);
            unit.UserRepository.Remove(user_t);
            unit.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unit.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
