using Zenject;

namespace PustoStudio.ClockApp.Bootstraping
{
    public sealed class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Bootstrap>()
                .AsTransient();
        }
    }
}
