using System;

namespace InventorySystemRepository
{
    public interface IBaseRepository<T> where T : class
    {
        void Save();
    }
}
