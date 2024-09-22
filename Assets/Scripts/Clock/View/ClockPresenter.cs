using System;
using PustoStudio.ClockApp.Clock.Model;
using R3;

using UnityEngine;

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
            _clockModel.CurrentTime
                .Subscribe(DisplayTime)
                .AddTo(ref _disposables);
        }

        public void Dispose()
        {
            _disposables.Dispose();
        }

        private void DisplayTime(DateTime? time)
        {
            _clockView.SetTime(time.GetValueOrDefault(DateTime.MinValue));
        }
    }
}
