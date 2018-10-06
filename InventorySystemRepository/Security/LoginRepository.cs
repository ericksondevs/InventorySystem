using InventorySystem.DataBase;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InventorySystemRepository.Security
{
    public class LoginRepository : BaseRepository<User_t>
    {
       
        public LoginRepository(System.Data.Entity.DbContext context) : base(context)
        {
        }

        public async Task<bool> Login(string email, string password)
        {
            if (await this.dbSet.AnyAsync(x => x.email == email && x.password == password))
            {
                return true;
            }
            return false;
        }
    }
}
