using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class UnitMetaData
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Unidad")]
        public int unit_id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Unidad")]
        public string description { get; set; }
    }
}
