using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoS.Models;

namespace SoS.Services
{
    public class DataStore<T> : IDataStore<T> where T : IBaseModel
    {
        internal readonly List<T> Items;

        public DataStore(IDatabase database)
        {
            Items = database.GetBaseModelTable<T>() as List<T>;
        }

        public async Task<bool> AddItemAsync(T item)
        {
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(T item)
        {
            var oldItem = Items.FirstOrDefault(x => x.Id == item.Id);
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.FirstOrDefault(x => x.Id == id);
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<T> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items as IEnumerable<T>);
        }
    }
}
