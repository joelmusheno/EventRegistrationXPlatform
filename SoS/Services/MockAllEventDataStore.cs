using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoS.Models;

namespace SoS.Services
{
    public class MockAllEventDataStore : IDataStore<InstructorLedEvent>
    {
        internal readonly List<InstructorLedEvent> Items;

        public MockAllEventDataStore(IDatabase database) 
        {
            Items = (List<InstructorLedEvent>)database.Events;
        }

        public async Task<bool> AddItemAsync(InstructorLedEvent item)
        {
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(InstructorLedEvent item)
        {
            var oldItem = Items.FirstOrDefault((InstructorLedEvent arg) => arg.Id == item.Id);
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.FirstOrDefault((InstructorLedEvent arg) => arg.Id == id);
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<InstructorLedEvent> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<InstructorLedEvent>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}