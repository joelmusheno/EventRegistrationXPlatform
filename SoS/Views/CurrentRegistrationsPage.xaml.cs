using System.ComponentModel;
using Xamarin.Forms;
using SoS.Models;
using SoS.ViewModels;

namespace SoS.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class CurrentRegistrationsPage : ContentPage
    {
        CurrentRegistrationsViewModel ViewModel;

        public CurrentRegistrationsPage()
        {
            InitializeComponent();
            BindingContext = ViewModel = new CurrentRegistrationsViewModel();
            registrationsListView.ItemsSource = ViewModel.Events;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is InstructorLedEvent item))
                return;

            var evd = new ItemDetailViewModel<IBaseEvent>(item);

            await Navigation.PushAsync(new EventDetailPage(evd));

            // Manually deselect item.
            // ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Events.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }
    }
}