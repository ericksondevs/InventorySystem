using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class WarehouseMetaData
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Almacen")]
        public int warehouse_id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Almacen")]
        public string name { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Direccion")]
        public string address { get; set; }
    }
}
