using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class RepoBase<T> : IRepo<T> where T : class
    {
        protected DbContext context;
        protected DbSet<T> table;
        public RepoBase(DbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public int Count() => table.Count();
        public int Count(Func<T, bool> func) => table.Count(func);
        public int GetCollectionCount(string collectionName, int id, int idSecond = 0)
        {
          
            T entity = GetItem(id, idSecond);
            int count = (context.Entry(entity).Collection(collectionName).Query() as IQueryable<T>).Count();
            return count;
        }
        public void Create(T item)
        {
            table.Add(item);
        }

        public async Task CreateAsync(T item)
        {
            await table.AddAsync(item);
        }

        public void Delete(T item)
        {
            table.Remove(item);
            
        }

        public Task DeleteAsync(T item)
        {
            return Task.Factory.StartNew(() =>
            {
                table.Remove(item);
            });
        }

        public IQueryable<T> GetAll()
        {
            return table.AsNoTracking();
        }

       

        public T GetItem(int id, int idSecond = 0)
        {
            var entity = table.Find(id);
            context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<T> GetItemAsync(int id, int idSecond = 0)
        {
            var entity = await table.FindAsync(id);
            context.Entry(entity).State = EntityState.Detached;
            return entity;            
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Update(T item)
        {
            table.Update(item);
        }

        public Task UpdateAsync(T item)
        {
            return Task.Factory.StartNew(() =>
            {
                table.Update(item);
            });
        }

      
    }
}
