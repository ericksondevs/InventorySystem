using InventorySystem.DataBase;
using InventorySystemRepository.Repositories.Operations;
using InventorySystemRepository.Repositories.Products;
using InventorySystemRepository.Repositories.ProductsRepo;
using InventorySystemRepository.Repositories.WareHouse;
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


        private SellRepository sellRepository;

        public SellRepository SellRepository
        {
            get
            {
                if (this.sellRepository == null)
                {
                    this.sellRepository = new SellRepository(dbContext);
                }
                return sellRepository;
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

        private BaseRepository<Person_t> personRepository;

        public BaseRepository<Person_t> PersonRepository
        {
            get
            {
                if (this.personRepository == null)
                {
                    this.personRepository = new BaseRepository<Person_t>(dbContext);
                }
                return personRepository;
            }
        }

        private WareHouseRepository wareHouseRepository;

        public WareHouseRepository WareHouseRepository
        {
            get
            {
                if (this.wareHouseRepository == null)
                {
                    this.wareHouseRepository = new WareHouseRepository(dbContext);
                }
                return wareHouseRepository;
            }
        }

        private RepositoryProduct repositoryProducts;
        public RepositoryProduct RepositoryProducts
        {
            get
            {
                if (this.repositoryProducts == null)
                {
                    this.repositoryProducts = new RepositoryProduct(dbContext);
                }
                return repositoryProducts;
            }
        }

        private OperationsProduct operationsProduct;

        public OperationsProduct OperationsProduct
        {
            get
            {
                if (this.operationsProduct == null)
                {
                    this.operationsProduct = new OperationsProduct(dbContext);
                }
                return operationsProduct;
            }
        }

        public void SaveChanges()
        {
            AddLogInfo();

            try
            {
                dbContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
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