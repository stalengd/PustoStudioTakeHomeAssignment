using System;
using R3;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class TimeEditDrag : TimeEditBase, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private float _sensetivity = 10f;

        public override ReactiveProperty<DateTime> Value { get; } = new();

        public override void SetActive(bool isActive)
        {
            enabled = isActive;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            Value.Value += TimeSpan.FromSeconds(_sensetivity * eventData.delta.x);
        }

        public void OnEndDrag(PointerEventData eventData)
        {

        }
    }
}
