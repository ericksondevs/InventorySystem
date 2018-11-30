using InventorySystem.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemRepository.Repositories.Operations
{
    public class SellRepository : BaseRepository<Sell_t>
    {
        public SellRepository(System.Data.Entity.DbContext context) : base(context)
        {

        }

        public string CreateOperation(Sell_t sell, Operation_t op)
        {
            var product = this.context.Set<Product_t>().Where(x => x.product_id == op.product_id).First();
            if (sell.Operation_type_Id == 1)
            {
                product.existence = (product.existence + (decimal)sell.total);
            }
            else
            {if (product.existence != 0)
                {
                    if ((product.existence-(decimal)sell.total) < 0)
                    {
                        return $"La venta supera la cantidad total de este producto. Cantidad: {product.existence}";
                    }
                    product.existence = (product.existence - (decimal)sell.total);
                }
                else
                {
                    return "No existe inventario de este producto.";
                }
            }
            this.dbSet.Add(sell);
            this.context.Set<Operation_t>().Add(op);

            return "OK";
        }
    }
}
