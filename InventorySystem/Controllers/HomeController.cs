using InventorySystem.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        private InventorySystemEntities db = new InventorySystemEntities();

        // GET: Home
        public ActionResult Index(string SearchText)
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                //  var result = db.inventario_v.ToList().Where(s => s.Producto.Contains(SearchText));
                var result = db.Product_t.ToList().Where(s => s.name.Contains(SearchText));

                return View(result.ToList());
            }
            return View(db.Product_t.ToList());
        }
    }
}