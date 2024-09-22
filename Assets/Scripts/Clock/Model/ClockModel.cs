using System;
using R3;

namespace PustoStudio.ClockApp.Clock.Model
{
    public sealed class ClockModel
    {
        public ReadOnlyReactiveProperty<DateTime?> CurrentTime => _currentTime;

        private DateTime? _baselineTime;
        private TimeSpan _passedFromBaseline;
        private readonly ReactiveProperty<DateTime?> _currentTime = new(null);

        public void SetTime(DateTime time)
        {
            _baselineTime = time;
            _passedFromBaseline = TimeSpan.Zero;
            RefreshCurrentTime();
        }

        public void Tick(TimeSpan amount)
        {
            if (amount < TimeSpan.Zero)
            {
                throw new ArgumentException("You should not tick negative amount of time", nameof(amount));
            }
            _passedFromBaseline += amount;
            RefreshCurrentTime();
        }

        private void RefreshCurrentTime()
        {
            if (_baselineTime is not { } baselineTime)
            {
                _currentTime.Value = null;
                return;
            }
            _currentTime.Value = baselineTime + _passedFromBaseline;
        }
    }
}