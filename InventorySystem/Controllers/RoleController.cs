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
    public class RoleController : Controller
    {
        UnitOfWork unit = new UnitOfWork();
        // GET: Role
        public ActionResult Index()
        {
            return View(unit.RoleRepository.GetAll().ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Role_t role_t = unit.RoleRepository.Get(x => x.role_id == id);
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
        public ActionResult Create([Bind(Include = "role_id,description")] Role_t role_t)
        {
            if (ModelState.IsValid)
            {
                unit.RoleRepository.Add(role_t);
                unit.SaveChanges();
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
            Role_t role_t = unit.RoleRepository.Get(x => x.role_id == id);
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
                var dbrol = unit.RoleRepository.Get(x => x.role_id == role_t.role_id);
                dbrol.description = role_t.description;

                unit.RoleRepository.Update(dbrol);
                unit.SaveChanges();

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

            Role_t role_t = unit.RoleRepository.Get(x => x.role_id == id);
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
            Role_t role_t = unit.RoleRepository.Get(x => x.role_id == id);
            unit.RoleRepository.Remove(role_t);
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
