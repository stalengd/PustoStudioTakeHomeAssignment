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
        private readonly ClockView _clockView;

        private DisposableBag _disposables;
        private bool _isEditing = false;
        private DateTime? _editedTime;

        public ClockPresenter(ClockModel clockModel, ClockView clockView)
        {
            _clockModel = clockModel;
            _clockView = clockView;
        }

        public void Initialize()
        {
            DisplayTime(_clockModel.CurrentTime.CurrentValue, isInstant: true);
            _clockView.ToggleEdit(false);
            _clockModel.CurrentTime
                .Subscribe(OnCurrentTimeChanged)
                .AddTo(ref _disposables);
            _clockView.EditClicked
                .Subscribe(_ => OnEditPressed())
                .AddTo(ref _disposables);
            _clockView.TimeEdited
                .Subscribe(OnTimeEdited)
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

        private void OnEditPressed()
        {
            _isEditing = !_isEditing;
            _clockView.ToggleEdit(_isEditing);
            if (_isEditing)
            {
                _editedTime = null;
            }
            else
            {
                Debug.Log(_editedTime);
                if (_editedTime.HasValue)
                {
                    _clockModel.SetOffsettedTime(_editedTime.Value);
                }
            }
        }

        private void OnTimeEdited(DateTime time)
        {
            _editedTime = time;
            DisplayTime(time, isInstant: true);
        }

        private void OnCurrentTimeChanged(DateTime? time)
        {
            if (_isEditing)
            {
                return;
            }
            DisplayTime(time, isInstant: false);
        }
    }
}
