using System;
using Cysharp.Threading.Tasks;
using PustoStudio.ClockApp.Rest;

namespace PustoStudio.ClockApp.Clock.ServerTime
{
    public sealed class ServerTimeProviderYandex : IServerTimeProvider
    {
        private readonly ClockConfig _clockConfig;
        private readonly RestClient _restClient;

        public ServerTimeProviderYandex(ClockConfig clockConfig, RestClient restClient)
        {
            _clockConfig = clockConfig;
            _restClient = restClient;
        }

        public async UniTask<DateTime?> GetCurrentTime()
        {
            var result = await _restClient.Get<YandexTimeResponse>(_clockConfig.CurrentTimeApiEndpoint);
            if (result.TryGet(out var timeResponse))
            {
                return new DateTime(TimeSpan.FromMilliseconds(timeResponse.time).Ticks, DateTimeKind.Utc);
            }
            return null;
        }
    }
}
