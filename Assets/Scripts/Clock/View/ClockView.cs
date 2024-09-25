using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class ClockView : MonoBehaviour
    {
        [SerializeField] private Button _editButton;
        [SerializeField] private GameObject _editingIndicator;
        [SerializeField] private TimeDisplayBase _display;
        [SerializeField] private TimeEditBase _edit;

        public Observable<Unit> EditClicked => _editButton.OnClickAsObservable();
        public Observable<DateTime> TimeEdited => _edit.Value;

        public void SetTime(DateTime time, bool isInstant)
        {
            _display.SetTime(time, isInstant);
            _edit.Value.Value = time;
        }

        public void ToggleEdit(bool isEditActive)
        {
            _edit.SetActive(isEditActive);
            _editingIndicator.SetActive(isEditActive);
        }
    }
}
