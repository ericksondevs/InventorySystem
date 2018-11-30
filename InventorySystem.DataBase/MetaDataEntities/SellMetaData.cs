using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class SellMetaData
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("total")]
        public double total { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("monto")]
        public double cash { get; set; }

        [DisplayName("descuento")]
        public string discount { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Cliente")]
        public int Person_Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Tipo de Operacion")]
        public int Operation_type_Id { get; set; }
       
    }
}
