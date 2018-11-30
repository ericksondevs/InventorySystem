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
    public class WarehouseController : Controller
    {
        //private InventorySystemEntities db = new InventorySystemEntities();
        UnitOfWork unit = new UnitOfWork();

        // GET: Warehouse
        public ActionResult Index()
        {
           
            return View(unit.WareHouseRepository.GetAll().ToList());
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            Warehouse_t warehouse_t = unit.WareHouseRepository.Get(x => x.warehouse_id == id);
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
        public ActionResult Create([Bind(Include = "warehouse_id,name,address")] Warehouse_t warehouse_t)
        {
            if (ModelState.IsValid)
            {
                unit.WareHouseRepository.Add(warehouse_t);
                unit.SaveChanges();
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
            Warehouse_t warehouse_t = unit.WareHouseRepository.Get(x => x.warehouse_id == id);
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
        public ActionResult Edit([Bind(Include = "warehouse_id,name,address")] Warehouse_t warehouse_t)
        {
            if (ModelState.IsValid)
            {
                unit.dbContext.Entry(warehouse_t).State = EntityState.Modified;
                unit.SaveChanges();
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
            Warehouse_t warehouse_t = unit.WareHouseRepository.Get(x => x.warehouse_id == id);
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
            Warehouse_t warehouse_t = unit.WareHouseRepository.Get(x => x.warehouse_id == id);
            unit.WareHouseRepository.Remove(warehouse_t);
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
