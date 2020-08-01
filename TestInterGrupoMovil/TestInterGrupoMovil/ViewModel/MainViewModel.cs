using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestInterGrupoMovil.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public HomeViewModel Home { get; set; }

        #region constructor
        public MainViewModel()
        {
            instance = this;
            Home = new HomeViewModel();
        }
        #endregion

        private static MainViewModel instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                instance = new MainViewModel();
            }

            return instance;
        }

    }
}
