using System;
using UnityEngine;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class ClockViewComposed : ClockViewBase
    {
        [SerializeField] private ClockViewBase[] _views;

        public override void SetTime(DateTime time)
        {
            foreach (var view in _views)
            {
                view.SetTime(time);
            }
        }
    }
}
