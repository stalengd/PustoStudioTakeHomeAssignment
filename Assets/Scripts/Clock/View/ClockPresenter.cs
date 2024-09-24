using System;
using PustoStudio.ClockApp.Clock.Model;
using R3;
using Zenject;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class ClockPresenter : IInitializable, IDisposable
    {
        private readonly ClockModel _clockModel;
        private readonly ClockViewBase _clockView;

        private DisposableBag _disposables;

        public ClockPresenter(ClockModel clockModel, ClockViewBase clockView)
        {
            _clockModel = clockModel;
            _clockView = clockView;
        }

        public void Initialize()
        {
            DisplayTime(_clockModel.CurrentTime.CurrentValue, isInstant: true);
            _clockModel.CurrentTime
                .Subscribe(time => DisplayTime(time, isInstant: false))
                .AddTo(ref _disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void DisplayTime(DateTime? time, bool isInstant = false)
        {
            _clockView.SetTime(time.GetValueOrDefault(DateTime.MinValue), isInstant);
        }
    }
}
