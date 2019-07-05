using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SoS.Views;
using Xamarin.Forms;

namespace SoS
{
    public partial class AppShell : Shell
    {
        public Dictionary<string, Type> Routes { get; } = new Dictionary<string, Type>();

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        public void RegisterRoutes()
        {
            Routes.Add(Constants.AboutPage, typeof(AboutPage));
            Routes.Add(Constants.CurrentRegistrations, typeof(CurrentRegistrationsPage));
        }


    }
}