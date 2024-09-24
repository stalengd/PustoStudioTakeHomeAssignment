using System;
using UnityEngine;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class ClockViewAnalog : ClockViewBase
    {
        [SerializeField] private Transform _hourHand;
        [SerializeField] private Transform _minuteHand;
        [SerializeField] private Transform _secondHand;

        public override void SetTime(DateTime dateTime)
        {
            var time = dateTime.TimeOfDay;
            SetHand(_hourHand, GetHoursAngle(time));
            SetHand(_minuteHand, GetMinutesAngle(time));
            SetHand(_secondHand, GetSecondsAngle(time));
        }

        private static void SetHand(Transform hand, float angle)
        {
            hand.localRotation = Quaternion.Euler(0, 0, angle);
        }

        private static float GetHoursAngle(TimeSpan time)
        {
            return -(float)time.TotalHours / 12 * 360f;
        }

        private static float GetMinutesAngle(TimeSpan time)
        {
            return -(float)time.TotalMinutes / 60 * 360f;
        }

        private static float GetSecondsAngle(TimeSpan time)
        {
            return -(float)time.TotalSeconds / 60 * 360f;
        }
    }
}
