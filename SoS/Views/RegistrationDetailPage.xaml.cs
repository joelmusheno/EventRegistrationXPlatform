using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SoS.Models;
using SoS.Services;
using SoS.ViewModels;
using Xamarin.Forms;

namespace SoS.Views
{
    [QueryProperty(nameof(RegistrationId), "registrationId")]
    public partial class RegistrationDetailPage : ViewModelBasedContentPage<ItemDetailViewModel>
    {
        public string RegistrationId { get; set; }

        public RegistrationDetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (int.TryParse(RegistrationId, out var registrationId))
                await ViewModel.LoadRegistration(registrationId);
        }
    }
}
