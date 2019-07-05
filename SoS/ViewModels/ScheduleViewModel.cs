using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SoS.Models;
using SoS.ViewModels;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SoS
{
    public class ScheduleViewModel:BaseViewModel
    {
        public ObservableCollection<InstructorLedEvent> Events { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ScheduleViewModel()
        {
            Title = "Schedule";
            Events = new ObservableCollection<InstructorLedEvent>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Events.Clear();
                var items = await EventDataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Events.Add(item);
                }
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
