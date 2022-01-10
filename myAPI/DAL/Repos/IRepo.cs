using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public interface IRepo<T> where T : class
    {
        int GetCollectionCount(string collectionName, int id, int idSecond = 0);
        IQueryable<T> GetAll();
        void Delete(T item);
        Task DeleteAsync(T item);
        void Create(T item);
        Task CreateAsync(T item);
        void Update(T item);
        Task UpdateAsync(T item);
        void Save();
        Task SaveAsync();
        T GetItem(int id, int idSecond = 0);
        Task<T> GetItemAsync(int id, int idSecond = 0);

    }
}
