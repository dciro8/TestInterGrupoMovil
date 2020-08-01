using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using TestInterGrupoMovil.AutoFac;

namespace TestInterGrupoMovil.ViewModel
{
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            BootsTrap.Initialize();
        }

        public HomeViewModel Main
        {
            get
            {
              return  ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }
    }
}
