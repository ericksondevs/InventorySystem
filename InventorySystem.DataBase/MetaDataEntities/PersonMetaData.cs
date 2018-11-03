using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class PersonMetaData
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Nombre")]
        public string name { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Apellido")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Compañia")]
        public string company { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Dirección 1")]
        public string address1 { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Dirección 2")]
        public string address2 { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Teléfono")]
        public string phone { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Correo Electrónico")]
        public string email { get; set; }

    }
}
