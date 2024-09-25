using PustoStudio.ClockApp.Clock.ServerTime;
using UnityEngine;
using Zenject;

namespace PustoStudio.ClockApp.Clock.Model
{
    public sealed class ClockModelInstaller : MonoInstaller
    {
        [SerializeField] private ClockConfig _clockConfig;

        public override void InstallBindings()
        {
            Container.Bind<ClockModel>()
                .ToSelf()
                .AsSingle();
            Container.BindInterfacesAndSelfTo<ClockService>()
                .AsSingle();
            Container.Bind<IServerTimeProvider>()
                .To<ServerTimeProviderTimeApiIo>()
                .AsSingle();
            Container.Bind<ClockConfig>()
                .FromInstance(_clockConfig);
        }
    }
}