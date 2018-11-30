using InventorySystem.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemRepository.Repositories.WareHouse
{
    public class WareHouseRepository : BaseRepository<Warehouse_t>
    {
        public WareHouseRepository(System.Data.Entity.DbContext context) : base(context)
        {

        }
    }
}
