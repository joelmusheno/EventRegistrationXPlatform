using Autofac;
using SoS.Services;
using SoS.ViewModels;
using System;
namespace SoS
{
    public class AppSetup
    {

        public IContainer CreateContainer()
        {
            var containerBuilder = new ContainerBuilder();
            RegisterDependencies(containerBuilder);
            return containerBuilder.Build();
        }

        protected virtual void RegisterDependencies(ContainerBuilder cb)
        {
            // Register Services
            cb.RegisterType<MockDatabase>().As<IDatabase>();
            cb.RegisterGeneric(typeof(DataStore<>)).As(typeof(IDataStore<>));
            cb.RegisterType<GroupingEventsService>().As<IGroupingEventsService>();

            // Register View Models
            cb.RegisterType<CurrentRegistrationsViewModel>().SingleInstance();
            cb.RegisterType<AboutViewModel>().SingleInstance();
            
        }
        
    }
}
