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

        public CurrentRegistrationsViewModel()
        {
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
                var events = await RegistrationDataStore.GetItemsAsync(true);
                var groupedEvents = 
                    DependencyService.Get<IGroupingEventsService>().GetDayGroupings(events);

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