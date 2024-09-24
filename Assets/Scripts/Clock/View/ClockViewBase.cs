using System;
using UnityEngine;

namespace PustoStudio.ClockApp.Clock.View
{
    public abstract class ClockViewBase : MonoBehaviour
    {
        public abstract void SetTime(DateTime time, bool isInstant);
    }
}
