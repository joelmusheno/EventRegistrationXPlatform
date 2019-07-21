using System.ComponentModel;
using Xamarin.Forms;
using SoS.Models;
using SoS.ViewModels;
using SoS.Services;
using System.Threading.Tasks;

namespace SoS.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    [QueryProperty(nameof(EventId), "id")]
    public partial class EventDetailPage : ContentPage
    {
        private ItemDetailViewModel<IBaseEvent> _viewModel;
        protected readonly IDataStore<InstructorLedEvent> EventDataStore;
        public int EventId { get; set; }

        public EventDetailPage()
        {
            EventDataStore = DependencyService.Get<IDataStore<InstructorLedEvent>>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var eventItem = await EventDataStore.GetItemAsync(EventId);

            _viewModel = new ItemDetailViewModel<IBaseEvent>(eventItem);
            BindingContext = _viewModel;
        }
    }
}