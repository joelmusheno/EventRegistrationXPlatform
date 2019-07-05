using System.Collections.Generic;
using System.Threading.Tasks;
using SoS.Models;

namespace SoS.Services
{
    public interface IDataStore<T>  where T: IBaseEvent
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(int id);
        Task<T> GetItemAsync(int id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
