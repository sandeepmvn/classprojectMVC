using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web;

namespace WebApplication3.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        void Dispose();
    }


    public class GenericRepository<T> : IDisposable,IRepository<T> where T : class
    {
        WebDemoEntities db = HelperContext.GetContext();
        DbSet<T> ds;
        ObjectCache cache = MemoryCache.Default;
        public GenericRepository()
        {
            ds = db.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            Type t = typeof(T);
            string key = t.ToString();
            if (cache[key] == null)
            {
                cache[key] = ds.ToList();
            }
            return (IEnumerable<T>)cache[key];
        }

        public T Get(int id)
        {
            return ds.Find(id);
        }

        public void Insert(T entity)
        {
            ds.Add(entity);
            db.SaveChanges();
            Type t = typeof(T);
            string key = t.ToString();
            cache.Remove(key);
        }

        public void Update(T entity)
        {
            db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            Type t = typeof(T);
            string key = t.ToString();
            cache.Remove(key);
        }

        public void Delete(int id)
        {
            T entity = ds.Find(id);
            ds.Remove(entity);
            db.SaveChanges();
            Type t = typeof(T);
            string key = t.ToString();
            cache.Remove(key);
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }



    public class Rep<T> : IRepository<T>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}