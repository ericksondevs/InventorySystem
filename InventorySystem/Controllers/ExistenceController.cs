using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventorySystem.DataBase;

namespace InventorySystem.Controllers
{
    public class ExistenceController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();
        // GET: Existence
        public ActionResult Index()
        {
            var product_t = db.Product_t.Include(p => p.Category_t).Include(p => p.Unit_t).Include(p => p.Warehouse_t);
            return View(product_t.ToList());
        }
    }
}