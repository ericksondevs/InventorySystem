using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class RoleMetaData
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Rol")]
        public string description { get; set; }
    }
}
