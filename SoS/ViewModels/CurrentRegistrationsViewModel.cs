using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using SoS.Models;
using SoS.Views;
using SoS.Services;

namespace SoS.ViewModels
{
    public class CurrentRegistrationsViewModel : BaseViewModel
    {
        public ObservableCollection<DayGroupedEventList> Events { get; set; }
        public Command LoadItemsCommand { get; set; }
        protected IGroupingEventsService GroupingEventsService { get; }
        protected IDataStore<EventRegistration> EventRegistrations { get; }

        public CurrentRegistrationsViewModel(IGroupingEventsService groupingEventsService, IDataStore<EventRegistration> eventRegistrations)
        {
            EventRegistrations = eventRegistrations;
            GroupingEventsService = groupingEventsService;

            Title = "Registrations";
            Events = new ObservableCollection<DayGroupedEventList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, InstructorLedEvent>(this, "AddItem", async (obj, item) =>
            {
                // add code to regroup.
                //var newItem = item as Event;
                //Events.Add(newItem);
                //await EventDataStore.AddItemAsync(newItem);
            });
            
            
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Events.Clear();
                var events = await EventRegistrations.GetItemsAsync(true);
                var groupedEvents = GroupingEventsService.GetDayGroupings(events);

                foreach (var ge in groupedEvents)
                    Events.Add(ge);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}