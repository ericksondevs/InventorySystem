using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventorySystem.DataBase.MetaDataEntities
{
    public class User_tMetaData
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Correo electrónico")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Correo electrónico inválido")]
        public string email { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Rol")]
        public Nullable<int> role_id { get; set; }
    }
}
