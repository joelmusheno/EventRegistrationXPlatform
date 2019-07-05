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

        public MockAllEventDataStore()
        {
            Items = new List<InstructorLedEvent>();
            var mockItems = new List<InstructorLedEvent>
            {
                new InstructorLedEvent 
                {   Id = 1, 
                    Name = "First item", 
                    Description="This is an item description.", 
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(1)
                },
                new InstructorLedEvent 
                { 
                    Id = 2, 
                    Name = "Second item", 
                    Description="This is an item description.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(1)

                },
                new InstructorLedEvent
                {
                    Id = 3,
                    Name = "Third item",
                    Description="This is an item description.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(1)

                },
                new InstructorLedEvent
                {
                    Id = 4,
                    Name = "Fouth item",
                    Description="This is an item description.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(1)

                },
                new InstructorLedEvent
                {
                    Id = 5,
                    Name = "Fifth item",
                    Description="This is an item description.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(1)

                },
                new InstructorLedEvent
                {
                    Id = 6,
                    Name = "Sixth item",
                    Description="This is an item description.",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddHours(1)
                },
            };

            foreach (var item in mockItems)
            {
                Items.Add(item);
            }
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