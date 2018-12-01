using InventorySystemRepository;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class PDFController : Controller
    {

        UnitOfWork repo = new UnitOfWork();
        // GET: PDF
        public ActionResult GetAllProducts()
        {
            var products = repo.RepositoryProducts.GetAll().ToList();
            return View(products);
        }

        public ActionResult PrintAll()
        {
            return new ActionAsPdf("GetAllProducts");
        }

        public ActionResult Movimientos(int id)
        {
           return View(repo.OperationsProduct.GetAll().Where(x => x.product_id == id));
        }
        public ActionResult PrintProductDetail()
        {
            return new ActionAsPdf("Movimientos");
        }

        public ActionResult GetAllSales()
        {
            var Sales = repo.SellRepository.GetAll().ToList();
            return View(Sales);

        }

        public ActionResult PrintSells()
        {
            return new ActionAsPdf("PrintSales");
        }

        public ActionResult GetSellsDetails(int id)
        {
            return View(repo.OperationsProduct.GetAll().Where(x => x.product_id == id).ToList());
        }
        public ActionResult PrintSaleDatail()
        {
            return new ActionAsPdf("GetSellsDetails");
        }

        public ActionResult GetAllBought()
        {
            //var Bought = repo.OperationsProduct.GetAll().Where(x=> x.Operation_type_t. == 1 ).ToList();
            return View(new List<String>());
        }
    }
}