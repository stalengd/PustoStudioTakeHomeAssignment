using System;
using UnityEngine;

namespace PustoStudio.ClockApp.Clock
{
    [CreateAssetMenu(menuName = "Configs/Clock")]
    public sealed class ClockConfig : ScriptableObject
    {
        [SerializeField] private string _currentTimeApiEndpoint;
        [SerializeField] private float _currentTimeLoadIntervalSeconds;

        public string CurrentTimeApiEndpoint => _currentTimeApiEndpoint;
        public TimeSpan CurrentTimeLoadInterval => TimeSpan.FromSeconds(_currentTimeLoadIntervalSeconds);
    }
}