using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SoS.Models;
using SoS.ViewModels;

namespace SoS.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class EventDetailPage : ContentPage
    {
        ItemDetailViewModel<IBaseEvent> viewModel;

        public EventDetailPage(ItemDetailViewModel<IBaseEvent> viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }
    }
}