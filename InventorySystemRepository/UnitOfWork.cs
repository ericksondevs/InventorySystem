using InventorySystem.DataBase;
using InventorySystemRepository.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystemRepository
{
    public class UnitOfWork : DbContext
    {
        private InventorySystemEntities context = new InventorySystemEntities();
        private LoginRepository loginRepository;

        public LoginRepository LoginRepository
        {
            get
            {
                if (this.loginRepository == null)
                {
                    this.loginRepository = new LoginRepository(context);
                }
                return loginRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
