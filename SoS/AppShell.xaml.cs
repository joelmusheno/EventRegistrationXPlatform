using System;
using System.Collections.Generic;

using Xamarin.Forms;
using SoS.Views;

namespace SoS
{
    public partial class AppShell : Shell
    {
        protected readonly Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes => routes;

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add(nameof(CurrentRegistrationsPage), typeof(CurrentRegistrationsPage));
            routes.Add(nameof(AboutPage), typeof(AboutPage));
            routes.Add(nameof(EventDetailPage), typeof(EventDetailPage));
            routes.Add(nameof(RegistrationDetailPage), typeof(RegistrationDetailPage));

            foreach (var item in routes)
                Routing.RegisterRoute(item.Key, item.Value);
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
