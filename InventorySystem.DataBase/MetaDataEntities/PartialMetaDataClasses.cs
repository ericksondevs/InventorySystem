﻿using InventorySystem.DataBase.MetaDataEntities;
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

    [MetadataType(typeof(SellMetaData))]
    public partial class Sell_t : BaseMetaDataEntity { }

    [MetadataType(typeof(PersonMetaData))]
    public partial class Person_t : BaseMetaDataEntity { }

    [MetadataType(typeof(WarehouseMetaData))]
    public partial class Warehouse_t : BaseMetaDataEntity { }

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product_t : BaseMetaDataEntity { }

    [MetadataType(typeof(UnitMetaData))]
    public partial class Unit_t : BaseMetaDataEntity { }

    [MetadataType(typeof(CategoryMetaData))]
    public partial class Category_t : BaseMetaDataEntity { }
}

