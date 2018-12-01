using InventorySystem.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            NewProducts = new List<Product_t>();
            ProductsFinishing = new List<Product_t>();
            LastSales = new List<Sell_t>();
        }
        public Decimal AbsoluteInventary { get; set; }

        public int TotalProducts { get; set; }

        public double SellsCash { get; set; }

        public int SellsTotal { get; set; }

        public double PurshaseCash { get; set; }

        public int PurchaseTotal { get; set; }

        public int Clients { get; set; }

        public int NewClients { get; set; }

        public List<Product_t> NewProducts { get; set; }

        public List<Product_t> ProductsFinishing { get; set; }

        public List<Sell_t> LastSales { get; set; }

        public Product_t Products { get; set; }

        public Sell_t Sell { get; set; }
    }
}