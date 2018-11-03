﻿using System;
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
    public class PersonController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();
        UnitOfWork unit = new UnitOfWork();
        // GET: Person
        public ActionResult Index()
        {
            return View(db.Person_t.ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person_t person_t = db.Person_t.Find(id);
            if (person_t == null)
            {
                return HttpNotFound();
            }
            return View(person_t);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,lastName,company,address1,address2,phone,email")] Person_t person_t)
        {
            if (ModelState.IsValid)
            {
                db.Person_t.Add(person_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person_t);
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person_t person_t = db.Person_t.Find(id);
            if (person_t == null)
            {
                return HttpNotFound();
            }
            return View(person_t);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,lastName,company,address1,address2,phone,email,last_update_date,creation_date,last_user_update")] Person_t person_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person_t);
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person_t person_t = db.Person_t.Find(id);
            if (person_t == null)
            {
                return HttpNotFound();
            }
            return View(person_t);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Person_t person_t = db.Person_t.Find(id);
            db.Person_t.Remove(person_t);
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
