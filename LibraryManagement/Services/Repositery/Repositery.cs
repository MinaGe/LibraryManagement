using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Repositery
{
    public class Repositery<T> : IRepositery<T> where T : class
    {
        protected readonly LibraryDbContext context;

        public Repositery(LibraryDbContext context)
        {
            this.context = context;
        }
        protected void Save() => context.SaveChanges();
        public int Count(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate).Count();
        }

        public void Create(T entity)
        {
            context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            Save();
        }

        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return context.Set<T>().Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
