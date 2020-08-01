using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using TestInterGrupoMovil.ViewModel;
using Xamarin.Forms;

namespace TestInterGrupoMovil.AutoFac
{
    public class BootsTrap
    {
        public static void Initialize()
        {

            //DependencyService.Register<HomeViewModel>();            

            ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<HomeViewModel>().AsSelf();
            builder.RegisterType<HomeViewModel>().InstancePerLifetimeScope();

            IContainer container = builder.Build();
            AutofacServiceLocator asl = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => asl);

        }


    }
}
