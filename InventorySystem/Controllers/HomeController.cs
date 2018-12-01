using InventorySystem.DataBase;
using InventorySystem.Models.ViewModels;
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
        HomeViewModel homeView = new HomeViewModel();
        // GET: Home
        public ActionResult Index(string SearchText)
        {
            LoadDashBoardData();

            if (!string.IsNullOrEmpty(SearchText))
            {
                //  var result = db.inventario_v.ToList().Where(s => s.Producto.Contains(SearchText));
                var result = db.Product_t.ToList().Where(s => s.name.ToLower().Contains(SearchText.ToLower()));

                return View(result.ToList());
            }
            return View(homeView);
        }

        private void LoadDashBoardData()
        {
            try
            {
                if (db.Product_t.Any())
                {
                    homeView.AbsoluteInventary = db.Product_t.Select(x => x.price).Sum();
                    homeView.TotalProducts = db.Product_t.Count();
                }

                if (db.Sell_t.Any(x => x.Operation_type_Id == 2))
                {
                    homeView.SellsCash = db.Sell_t.Where(x => x.Operation_type_Id == 2).Select(x => x.cash).Sum();

                    homeView.SellsTotal = db.Sell_t.Where(x => x.Operation_type_Id == 2).Count();
                }

                if (db.Sell_t.Any(x => x.Operation_type_Id == 1))
                {
                    homeView.PurshaseCash = db.Sell_t.Where(x => x.Operation_type_Id == 1).Select(x => x.cash).Sum();

                    homeView.PurchaseTotal = db.Sell_t.Where(x => x.Operation_type_Id == 1).Count();
                }

                if (db.Person_t.Any())
                {
                    homeView.Clients = db.Person_t.Where(x => x.person_type == 1).Count();

                    homeView.NewClients = db.Person_t.Where(x => x.person_type == 1).Count();
                }

                if (db.Product_t.Any())
                {
                    homeView.NewProducts = db.Product_t.OrderBy(x => x.creation_Date).Take(5).ToList();

                    homeView.ProductsFinishing = db.Product_t.Where(x => x.existence < 50).OrderBy(x => x.creation_Date).Take(5).ToList();
                }


                if (db.Sell_t.Any())
                {
                    homeView.LastSales = db.Sell_t.OrderBy(x => x.Id).Take(5).ToList();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}