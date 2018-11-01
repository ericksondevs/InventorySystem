using InventorySystem.DataBase;
using InventorySystemRepository.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InventorySystemRepository
{
    public class UnitOfWork 
    {
        string onlineUser = HttpContext.Current.User.Identity.Name;

        public InventorySystemEntities dbContext { get; } = null;

        public UnitOfWork()
        {
            dbContext = new InventorySystemEntities();
        }

        private LoginRepository userRepository;

        public LoginRepository UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new LoginRepository(dbContext);
                }
                return userRepository;
            }
        }

        private BaseRepository<Role_t> roleRepository;

        public BaseRepository<Role_t> RoleRepository
        {
            get
            {
                if (this.roleRepository == null)
                {
                    this.roleRepository = new BaseRepository<Role_t>(dbContext);
                }
                return roleRepository;
            }
        }

        public void SaveChanges()
        {
            AddLogInfo();
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void AddLogInfo()
        {
            var entities = dbContext.ChangeTracker.Entries().Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));
            
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    if ((entity.Entity != null) && (entity.Entity.GetType().GetProperty("creation_Date") != null))
                    {
                        ((dynamic)entity.Entity).creation_Date = DateTime.Now;
                    }

                    if ((entity.Entity != null) && (entity.Entity.GetType().GetProperty("last_user_update") != null))
                    {
                        ((dynamic)entity.Entity).last_user_update = this.onlineUser;
                    }
                }

                if (entity.State == EntityState.Modified)
                {
                    if ((entity.Entity != null) && (entity.Entity.GetType().GetProperty("last_update_date") != null))
                    {
                        ((dynamic)entity.Entity).last_update_date = DateTime.Now;
                    }

                    if ((entity.Entity != null) && (entity.Entity.GetType().GetProperty("last_user_update") != null))
                    {
                        ((dynamic)entity.Entity).last_user_update = this.onlineUser;
                    }
                }
            }
        }
    }
}