using UnityEngine;
using Zenject;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class ClockViewInstaller : MonoInstaller
    {
        [SerializeField] private ClockViewBase _view;

        public override void InstallBindings()
        {
            Container.Bind<ClockViewBase>()
                .FromInstance(_view);
            Container.BindInterfacesAndSelfTo<ClockPresenter>()
                .AsSingle();
        }
    }
}
