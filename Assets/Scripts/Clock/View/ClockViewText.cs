using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace PustoStudio.ClockApp.Clock.View
{
    public sealed class ClockViewText : ClockViewBase
    {
        [SerializeField] private string _format = "{0:HH:mm:ss}";
        [SerializeField] private TMP_Text _text;

        private readonly StringBuilder _buffer = new();

        public override void SetTime(DateTime time)
        {
            _buffer.Clear();
            _buffer.AppendFormat(_format, time);
            _text.SetText(_buffer);
        }
    }
}
