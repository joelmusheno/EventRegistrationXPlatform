using System;
using Autofac;
using SoS.ViewModels;
using Xamarin.Forms;

namespace SoS.Views
{   
    public class ViewModelBasedContentPage<T> : ContentPage where T: IBaseViewModel
    {
        public T ViewModel { get; set;  }

        public ViewModelBasedContentPage()
        {
            using (var scope = AppContainer.Container.BeginLifetimeScope())
            {
                ViewModel = AppContainer.Container.Resolve<T>();
            }
            BindingContext = ViewModel;
        }
    }
}
