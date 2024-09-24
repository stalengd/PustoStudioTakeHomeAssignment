using System;
using DG.Tweening;
using UnityEngine;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class ClockViewAnalog : ClockViewBase
    {
        [Header("Hands")]
        [SerializeField] private Transform _hourHand;
        [SerializeField] private Transform _minuteHand;
        [SerializeField] private Transform _secondHand;

        [Header("Animation")]
        [SerializeField] private float _tweenDurationSeconds = 0.5f;
        [SerializeField] private Ease _tweenEase = Ease.InOutQuad;

        public override void SetTime(DateTime dateTime)
        {
            var time = dateTime.TimeOfDay;
            SetHand(_hourHand, GetHoursAngle(time));
            SetHand(_minuteHand, GetMinutesAngle(time));
            SetHand(_secondHand, GetSecondsAngle(time));
        }

        private void SetHand(Transform hand, float angle)
        {
            hand.DOLocalRotate(new(0, 0, angle), _tweenDurationSeconds).SetEase(_tweenEase);
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
