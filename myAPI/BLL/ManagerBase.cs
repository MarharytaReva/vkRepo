using DAL.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL
{
    public class ManagerBase<T, D> : IManager<D> where D : class where T: class
    {
        protected IRepo<T> repo;
        protected IMapper mapper;
        protected int paginationCount;
        public int PaginationCount { get => paginationCount; set => paginationCount = value < 1 ? 1 : value; }

        public ManagerBase(IRepo<T> repo, int paginationCount = 1)
        {
            this.repo = repo;
            this.paginationCount = paginationCount;
        }
        public async Task<int> GetCollectionCountAsync(string collectionName, int id, int idSecond = 0)
        {
            return await Task.Run(() =>
            {
               return repo.GetCollectionCount(collectionName, id, idSecond);
            });
        }

        protected Task<D> ConvertAsync(T enity)
        {
            Task<D> task = new Task<D>(() =>
            {
                return mapper.Map<T, D>(enity);
            });
            task.Start();
            return task;
        }
        protected Task<T> ConvertAsync(D item)
        {
            Task<T> task = new Task<T>(() =>
            {
                return mapper.Map<D, T>(item);
            });
            task.Start();
            return task;
        }
        public D Create(D item)
        {
            T entity = mapper.Map<D, T>(item);
            repo.Create(entity);
            repo.Save();
            return item;
        }

        public async Task<D> CreateAsync(D item)
        {
            T entity = await ConvertAsync(item);
            await repo.CreateAsync(entity);
            await repo.SaveAsync();
            return item;
        }

        public D Delete(int id)
        {
            T entity = repo.GetItem(id);
            repo.Delete(entity);
            repo.Save();
            D item = mapper.Map<T, D>(entity);
            return item;
        }

        public async Task<D> DeleteAsync(int id)
        {
            T entity = await repo.GetItemAsync(id);
            await repo.DeleteAsync(entity);
            await repo.SaveAsync();
            D item = await ConvertAsync(entity);
            return item;
        }

        public D Update(D item)
        {
            T entity = mapper.Map<D, T>(item);
            repo.Update(entity);
            repo.Save();
            return item;
        }

        public async Task<D> UpdateAsync(D item)
        {
            T entity = await ConvertAsync(item);
            await repo.UpdateAsync(entity);
            await repo.SaveAsync();
            return item;
        }

        public async Task<D> GetItemAsync(int id, int idSecond = 0)
        {
            T entity = await repo.GetItemAsync(id);
            if (entity is null)
                return null;
            D item = await ConvertAsync(entity);
            return item;
        }
        public int Count()
        {
            return repo.Count();
        }
        public int Count(Func<T, bool> func)
        {
            return repo.Count(func);
        }
    }
}
