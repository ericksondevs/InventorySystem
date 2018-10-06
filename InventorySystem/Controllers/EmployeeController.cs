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
    public class EmployeeController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();

        // GET: Employee
        public ActionResult Index()
        {
            var employee_t = db.Employee_t.Include(e => e.User_t).Include(e => e.Warehouse_t);
            return View(employee_t.ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_t employee_t = db.Employee_t.Find(id);
            if (employee_t == null)
            {
                return HttpNotFound();
            }
            return View(employee_t);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.User_t, "user_id", "email");
            ViewBag.warehouse_id = new SelectList(db.Warehouse_t, "warehouse_id", "name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "employee_id,first_name,last_name_1,last_name_2,identification,address,hiring_date,user_id,warehouse_id,last_update_date,creation_Date,last_user_update")] Employee_t employee_t)
        {
            if (ModelState.IsValid)
            {
                db.Employee_t.Add(employee_t);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.User_t, "user_id", "email", employee_t.user_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouse_t, "warehouse_id", "name", employee_t.warehouse_id);
            return View(employee_t);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_t employee_t = db.Employee_t.Find(id);
            if (employee_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.User_t, "user_id", "email", employee_t.user_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouse_t, "warehouse_id", "name", employee_t.warehouse_id);
            return View(employee_t);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employee_id,first_name,last_name_1,last_name_2,identification,address,hiring_date,user_id,warehouse_id,last_update_date,creation_Date,last_user_update")] Employee_t employee_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.User_t, "user_id", "email", employee_t.user_id);
            ViewBag.warehouse_id = new SelectList(db.Warehouse_t, "warehouse_id", "name", employee_t.warehouse_id);
            return View(employee_t);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee_t employee_t = db.Employee_t.Find(id);
            if (employee_t == null)
            {
                return HttpNotFound();
            }
            return View(employee_t);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee_t employee_t = db.Employee_t.Find(id);
            db.Employee_t.Remove(employee_t);
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
