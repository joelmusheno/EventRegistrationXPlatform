using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoS.Models;

namespace SoS.Services
{
    public class MockRegistrationDataStore : IDataStore<EventRegistration>
    {

        internal readonly List<EventRegistration> Items;

        public MockRegistrationDataStore()
        {
            Items = new List<EventRegistration>();
            var mockItems = new List<EventRegistration>
            {
                new EventRegistration
                {   Id = 1,
                    Name = "First item",
                    StartDate = DateTime.Now.AddHours(1),
                    EndDate = DateTime.Now.AddHours(2),
                    Seat = 11
                },
                new EventRegistration
                {   Id = 2,
                    Name = "Second item",
                    StartDate = DateTime.Now.AddDays(1).AddHours(1),
                    EndDate = DateTime.Now.AddDays(1).AddHours(2),
                    Seat = 11
                },
            };

            foreach (var item in mockItems)
            {
                Items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(EventRegistration item)
        {
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(EventRegistration item)
        {
            var oldItem = Items.FirstOrDefault((EventRegistration arg) => arg.Id == item.Id);
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.FirstOrDefault((EventRegistration arg) => arg.Id == id);
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<EventRegistration> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<EventRegistration>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }
    }
}
