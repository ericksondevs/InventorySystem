using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class CategoryMetaData
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Categoria")]
        public int category_id { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Categoria")]
        public string name { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Descripción")]
        public string description { get; set; }
    }
}
