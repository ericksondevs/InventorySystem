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
    public class ProviderController : Controller
    {
        // private InventorySystemEntities db = new InventorySystemEntities();
        UnitOfWork unit = new UnitOfWork();
        // GET: Person
        public ActionResult Index()
        {
            return View(unit.PersonRepository.GetWhere(x=>x.person_type == 2).ToList());
        }

        // GET: Person/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Person_t person_t = unit.PersonRepository.Get(x => x.Id == id);
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
                person_t.person_type = 2;
                unit.PersonRepository.Add(person_t);
                unit.SaveChanges();
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
            Person_t person_t = unit.PersonRepository.Get(x => x.Id == id);
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
        public ActionResult Edit([Bind(Include = "Id,name,lastName,company,address1,address2,phone,email")] Person_t person_t)
        {
            if (ModelState.IsValid)
            {
                unit.dbContext.Entry(person_t).State = EntityState.Modified;
                unit.SaveChanges();
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
            Person_t person_t = unit.PersonRepository.Get(x => x.Id == id);
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
            Person_t person_t = unit.PersonRepository.Get(x => x.Id == id);
            unit.PersonRepository.Remove(person_t);
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
