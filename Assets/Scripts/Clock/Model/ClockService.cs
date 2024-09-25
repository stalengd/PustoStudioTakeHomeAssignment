using System;
using Cysharp.Threading.Tasks;
using PustoStudio.ClockApp.Clock.ServerTime;
using UnityEngine;
using Zenject;

namespace PustoStudio.ClockApp.Clock.Model
{
    public sealed class ClockService : ITickable
    {
        private readonly ClockModel _clockModel;
        private readonly ClockConfig _clockConfig;
        private readonly IServerTimeProvider _serverTimeProvider;

        private const double TickIntervalSeconds = 0.5;
        private double _prevTickTime;
        private bool _isLoadingTime = false;
        private double _lastLoadTimestamp;

        public ClockService(ClockModel clockModel, ClockConfig clockConfig, IServerTimeProvider serverTimeProvider)
        {
            _clockModel = clockModel;
            _clockConfig = clockConfig;
            _serverTimeProvider = serverTimeProvider;
        }

        public UniTask Initialize()
        {
            return LoadCurrentTime(fallbackOnFailure: true);
        }

        public void Tick()
        {
            var localTime = Time.unscaledTimeAsDouble;
            if (localTime - _prevTickTime >= TickIntervalSeconds)
            {
                _clockModel.Tick(TimeSpan.FromSeconds(localTime - _prevTickTime));
                _prevTickTime = localTime;
            }
            if (IsTimeShouldBeReloaded())
            {
                LoadCurrentTime().Forget();
            }
        }

        private async UniTask LoadCurrentTime(bool fallbackOnFailure = false)
        {
            if (_isLoadingTime)
            {
                return;
            }
            _isLoadingTime = true;
            var timeOrNone = await _serverTimeProvider.GetCurrentTime();
            _lastLoadTimestamp = Time.unscaledTimeAsDouble;
            if (timeOrNone is { } time)
            {
                Debug.Log("Current time was successfully loaded from the server.");
                _clockModel.SetAbsoluteTime(time);
                _isLoadingTime = false;
                return;
            }
            if (fallbackOnFailure)
            {
                Debug.Log("Current time can not be loaded from the server, falling back to local.");
                _clockModel.SetAbsoluteTime(DateTime.UtcNow);
            }
            else
            {
                Debug.Log("Current time can not be loaded from the server, current time unchanged.");
            }
            _isLoadingTime = false;
        }

        private bool IsTimeShouldBeReloaded()
        {
            var localTime = Time.unscaledTimeAsDouble;
            return !_isLoadingTime &&
                (localTime - _lastLoadTimestamp) >= _clockConfig.CurrentTimeLoadInterval.TotalSeconds;
        }
    }
}