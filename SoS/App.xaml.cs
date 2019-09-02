using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Core;
using SoS.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SoS
{   
    public partial class App : Application
    {
        public static IContainer container;
        static readonly ContainerBuilder builder = new ContainerBuilder();

        public App(AppSetup setup)
        {
            InitializeComponent();

            AppContainer.Container = setup.CreateContainer();

            MainPage = new AppShell();

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
