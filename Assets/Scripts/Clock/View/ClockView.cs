using System;
using UnityEngine;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class ClockView : MonoBehaviour
    {
        [SerializeField] private TimeDisplayBase _display;

        public void SetTime(DateTime time, bool isInstant)
        {
            _display.SetTime(time, isInstant);
        }
    }
}
