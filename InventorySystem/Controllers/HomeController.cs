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
        public ActionResult Index()
        {
         
            return View(db.inventario_v.ToList());
       
        }
    }
}