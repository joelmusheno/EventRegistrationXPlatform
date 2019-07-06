using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SoS.Models;
using SoS.Services;
using Xamarin.Forms;

namespace SoS.Views
{
    [QueryProperty(nameof(RegistrationId), "registrationId")]
    public partial class RegistrationDetailPage : ContentPage
    {
        private ViewModels.ItemDetailViewModel<IBaseEvent> _viewModel;

        public string RegistrationId { get; set; }

        protected readonly IDataStore<EventRegistration> EventRegistrationDataStore;

        public RegistrationDetailPage()
        {
            InitializeComponent();

            EventRegistrationDataStore = DependencyService.Get<IDataStore<EventRegistration>>()
                ?? new MockRegistrationDataStore();
        }

        protected override async void OnAppearing()
        {
            if (int.TryParse(RegistrationId, out int registrationId))
            {
                var registration = await EventRegistrationDataStore.GetItemAsync(registrationId);
                _viewModel = new ViewModels.ItemDetailViewModel<IBaseEvent>(registration);
                BindingContext = _viewModel;
            }
        }
    }
}
