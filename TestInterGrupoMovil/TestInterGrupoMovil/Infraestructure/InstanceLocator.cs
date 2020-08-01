
using TestInterGrupoMovil.ViewModel;

namespace TestInterGrupoMovil.Infraestructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = new MainViewModel();

        }
    }
}
