using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestInterGrupoMovil.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestInterGrupoMovil.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();
        }
    }
}