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
            registrationsListView.ItemSelected += OnItemSelected;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is EventRegistration selectedRegistration))
                return;

            await Shell.Current.GoToAsync($"{nameof(RegistrationDetailPage)}?registrationId={selectedRegistration.Id}");

            // Manually deselect item.
            registrationsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (ViewModel.Events.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }
    }
}