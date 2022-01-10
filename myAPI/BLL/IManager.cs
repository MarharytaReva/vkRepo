using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public interface IManager<D> where D : class
    {
        Task<int> GetCollectionCountAsync(string collectionName, int id, int idSecond = 0);
        int PaginationCount { get; set; }
        D Delete(int id);
        Task<D> DeleteAsync(int id);
        D Create(D item);
        Task<D> CreateAsync(D item);
        D Update(D item);
        Task<D> UpdateAsync(D item);
        Task<D> GetItemAsync(int id, int idSecond = 0);

    }
}
