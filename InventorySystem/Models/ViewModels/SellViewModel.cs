﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using InventorySystem.DataBase;
namespace InventorySystem.Models.ViewModels
{
    public class SellViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("total")]
        public double total { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("monto")]
        public double cash { get; set; }

        public string discount { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Cliente")]
        public int Person_Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Tipo de Operacion")]
        public int Operation_type_Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Id del usuario")]
        public Nullable<int> user_id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Producto")]
        public int product_id { get; set; }


        public List<Sell_t> Sells { get; set; }

        public  Person_t Person_t { get; set; }
        public  Operation_type_t Operation_type_t { get; set; }
        public  User_t User_t { get; set; }



    }
}