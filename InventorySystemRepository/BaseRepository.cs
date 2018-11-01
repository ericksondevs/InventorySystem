﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace InventorySystemRepository
{
    public class BaseRepository<T> where T : class
    {
        internal DbContext context;
        internal DbSet<T> dbSet;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public T Get(Func<T, bool> predicate)
        {
            return GetWhere(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            return GetWhere(null);
        }

        public void Add(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }

        public IEnumerable<T> GetWhere(Func<T, bool> predicate)
        {
            IEnumerable<T> result = dbSet.AsEnumerable();
            return (predicate == null) ? result : result.Where<T>(predicate);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }


        public void Remove(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        //public virtual void Save()
        //{
        //    context.SaveChanges();
        //}
        //public void Dispose()
        //{
        //    if (context != null)
        //        context.Dispose();
        //}
    }
}
