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
    public partial class EventDetailPage : ViewModelBasedContentPage<ItemDetailViewModel>
    {
        public string EventId { get; set; }

        public EventDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (int.TryParse(EventId, out var eventId))
                await ViewModel.LoadEvent(eventId);
        }
    }
}