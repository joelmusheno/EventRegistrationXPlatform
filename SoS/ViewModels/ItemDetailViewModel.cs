using System;
using System.Threading.Tasks;
using SoS.Models;
using SoS.Services;

namespace SoS.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel 
    {
        public IBaseEvent Item { get; set; }
        private IDataStore<EventRegistration> _eventRegistrations;
        private readonly IDataStore<InstructorLedEvent> _eventDataStore;

        public ItemDetailViewModel(IDataStore<EventRegistration> eventRegistrations,
            IDataStore<InstructorLedEvent> eventDataStore)
        {
            _eventRegistrations = eventRegistrations;
            _eventDataStore = eventDataStore;
        }

        public async Task<IBaseEvent> LoadRegistration(int id)
        {
            Item = await _eventRegistrations.GetItemAsync(id);
            return Item;
        }

        public async Task<IBaseEvent> LoadEvent(int id)
        {
            Item = await _eventRegistrations.GetItemAsync(id);
            return Item;
        }
    }
}
