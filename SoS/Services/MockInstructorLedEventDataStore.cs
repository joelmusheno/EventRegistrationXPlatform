using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoS.Models;

namespace SoS.Services
{
    public class MockInstructorLedEventDataStore : IDataStore<InstructorLedEvent>
    {
        private readonly List<InstructorLedEvent> _instructorLedEvents;

        public MockInstructorLedEventDataStore(IDatabase database) 
        {
            _instructorLedEvents = (List<InstructorLedEvent>)database.Events;
        }

        public async Task<bool> AddItemAsync(InstructorLedEvent item)
        {
            _instructorLedEvents.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            if (_instructorLedEvents.Any(x => x.Id == id))
                _instructorLedEvents.Remove(_instructorLedEvents.FirstOrDefault(x => x.Id == id));
            return await Task.FromResult(true);
        }

        public async Task<InstructorLedEvent> GetItemAsync(int id)
        {
            return await Task.FromResult(_instructorLedEvents.FirstOrDefault(x => x.Id == id));

        }

        public async Task<IEnumerable<InstructorLedEvent>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(_instructorLedEvents as IEnumerable<InstructorLedEvent>);
        }

        public async Task<bool> UpdateItemAsync(InstructorLedEvent item)
        {
            if (!_instructorLedEvents.Any(x => x.Id == item.Id))
                return await Task.FromResult(false);

            _instructorLedEvents.Remove(_instructorLedEvents.FirstOrDefault(x => x.Id == item.Id));
            _instructorLedEvents.Add(item);
            return await Task.FromResult(true);
        }
    }
}
