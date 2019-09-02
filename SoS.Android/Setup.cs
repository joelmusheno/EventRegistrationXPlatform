using System;
using Autofac;
using CarouselView.FormsPlugin.Android;

namespace SoS.Droid
{
    public class Setup : AppSetup
    {
        protected override void RegisterDependencies(ContainerBuilder cb)
        {
            base.RegisterDependencies(cb);

            //cb.RegisterType<DroidHelloFormsService>().As<IHelloFormsService>();
            CarouselViewRenderer.Init();
        }
    }
}
