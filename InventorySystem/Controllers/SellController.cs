using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventorySystem.DataBase;
using InventorySystem.Models.ViewModels;
using InventorySystemRepository;

namespace InventorySystem.Controllers
{
    public class SellController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();
        SellViewModel sellVm = new SellViewModel();
        UnitOfWork unit = new UnitOfWork();

        // GET: Sell
        public ActionResult Index()
        {
            SellViewModel sell = new SellViewModel()
            {
                
                Sells = db.Sell_t.Include(s => s.Person_t).Include(s => s.Operation_type_t).Include(s => s.Operation_t).ToList()
            };
            if (sell.Sells.Any(x=>x.Operation_type_Id == 2))
            {
                sell.Sells = sell.Sells.Where(x => x.Operation_type_Id == 2).ToList();
            }
            return View(sell);
        }

        // GET: Sell/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell_t sell_t = db.Sell_t.Find(id);
            if (sell_t == null)
            {
                return HttpNotFound();
            }
            return View(sell_t);
        }

        // GET: Sell/Create
        public ActionResult Create()
        {
            SellViewModel sell = new SellViewModel()
            {

                Sells = db.Sell_t.Include(s => s.Person_t).Include(s => s.Operation_type_t).Include(s => s.Operation_t).Where(x => x.Operation_type_Id == 2).ToList()
            };

            ViewBag.Person_Id = new SelectList(db.Person_t.Where(x=>x.person_type ==1), "Id", "name");
            ViewBag.Operation_type_Id = new SelectList(db.Operation_type_t, "Id", "Description");
            ViewBag.user_id = new SelectList(db.User_t, "user_id", "email");
            ViewBag.product_id = new SelectList(db.Product_t, "product_id", "name");
            return View();
        }

        // POST: Sell/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,total,cash,discount,Person_Id,Operation_type_Id,product_id")] SellViewModel sellVm)
        {
           sellVm.user_id = Convert.ToInt32(User.Identity.Name);

           Sell_t sell = new Sell_t()
            {
                User_t = sellVm.User_t,
                Person_t = sellVm.Person_t,
                total = sellVm.total,
                cash = sellVm.cash,
                discount = sellVm.discount,
                Person_Id = sellVm.Person_Id,
                Operation_type_Id = 2,
                user_id = sellVm.user_id
            };

            Operation_t op = new Operation_t();
            op.product_id = sellVm.product_id;
            op.Sell_Id = sell.Id;
            op.Operation_type_Id = 2;
            string result = string.Empty;
            if (ModelState.IsValid)
            {
                result = unit.SellRepository.CreateOperation(sell, op);
                if (result == "OK")
                {
                    unit.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError("", "Error: " + result);
            ViewBag.Person_Id = new SelectList(db.Person_t.Where(x => x.person_type == 1), "Id", "name", sellVm.Person_Id);
            ViewBag.Operation_type_Id = new SelectList(db.Operation_type_t, "Id", "Description", sellVm.Operation_type_Id);
            ViewBag.user_id = new SelectList(db.User_t, "user_id", "email", sellVm.user_id);
            ViewBag.product_id = new SelectList(db.Product_t, "product_id", "name", sellVm.product_id);

            return View(sellVm);
        }

        // GET: Sell/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell_t sell_t = db.Sell_t.Find(id);
            if (sell_t == null)
            {
                return HttpNotFound();
            }
            ViewBag.Person_Id = new SelectList(db.Person_t.Where(x => x.person_type == 1), "Id", "name", sell_t.Person_Id);
            ViewBag.Operation_type_Id = new SelectList(db.Operation_type_t, "Id", "Description", sell_t.Operation_type_Id);
            ViewBag.user_id = new SelectList(db.User_t, "user_id", "email", sell_t.user_id);
            ViewBag.product_id = new SelectList(db.Product_t, "product_id", "name", sellVm.product_id);

            return View(sell_t);
        }

        // POST: Sell/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,total,cash,discount,Person_Id,user_id")] Sell_t sell_t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sell_t).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Person_Id = new SelectList(db.Person_t.Where(x => x.person_type == 1), "Id", "name", sell_t.Person_Id);
            ViewBag.Operation_type_Id = new SelectList(db.Operation_type_t, "Id", "Description", sell_t.Operation_type_Id);
            ViewBag.user_id = new SelectList(db.User_t, "user_id", "email", sell_t.user_id);
            ViewBag.product_id = new SelectList(db.Product_t, "product_id", "name", sellVm.product_id);

            return View(sell_t);
        }

        // GET: Sell/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sell_t sell_t = db.Sell_t.Find(id);
            if (sell_t == null)
            {
                return HttpNotFound();
            }
            return View(sell_t);
        }

        // POST: Sell/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sell_t sell_t = db.Sell_t.Find(id);
            db.Sell_t.Remove(sell_t);
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
