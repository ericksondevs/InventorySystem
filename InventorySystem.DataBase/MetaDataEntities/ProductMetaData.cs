using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class ProductMetaData
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Producto")]
        public string name { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Descripción")]
        public string description { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Precio")]
        public decimal price { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Existencia")]
        public decimal existence { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Unidad")]
        public Nullable<int> unit_id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Categoria")]
        public Nullable<int> category_id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Almacen")]
        public Nullable<int> warehouse_id { get; set; }
    }
}
