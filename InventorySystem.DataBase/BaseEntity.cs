using System;
using System.ComponentModel;

namespace InventorySystem.DataBase
{
    public abstract class BaseMetaDataEntity
    {
        [DisplayName("Ultima fecha actualización")]
        public Nullable<System.DateTime> last_update_date
        {
            get;set;
        }

        [DisplayName("Fecha creación")]
        public Nullable<System.DateTime> creation_Date
        {
            get; set;
        }

        [DisplayName("Ultimo usuario actualización")]
        public string last_user_update
        {
            get; set;
        }
    }
}