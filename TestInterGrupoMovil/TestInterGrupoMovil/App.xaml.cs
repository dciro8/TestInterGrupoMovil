using System;
using TestInterGrupoMovil.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestInterGrupoMovil
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage =   new HomePage();
            //MainPage = new ChartPage(); 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
