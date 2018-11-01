using InventorySystem.DataBase.CustomDataAnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class EmployeeMetaData 
    {

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Nombre")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Primer Apellido")]
        public string last_name_1 { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Segundo Apellido")]
        public string last_name_2 { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Cédula")]
        [IdentificationValidationAttribute]
        public string identification { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Dirección")]
        public string address { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Fecha de contratación")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> hiring_date { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Usuario")]
        public Nullable<int> user_id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Almacen")]
        public Nullable<int> warehouse_id { get; set; }
    }
}
