using InventorySystem.DataBase.MetaDataEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.DataBase
{
    [MetadataType(typeof(User_tMetaData))]
    public partial class User_t : BaseMetaDataEntity { }

    [MetadataType(typeof(RoleMetaData))]
    public partial class Role_t : BaseMetaDataEntity { }

    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee_t : BaseMetaDataEntity { }
}

