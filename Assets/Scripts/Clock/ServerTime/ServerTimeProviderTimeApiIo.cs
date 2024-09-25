using System;
using Cysharp.Threading.Tasks;
using PustoStudio.ClockApp.Rest;

namespace PustoStudio.ClockApp.Clock.ServerTime
{
    public sealed class ServerTimeProviderTimeApiIo : IServerTimeProvider
    {
        private readonly ClockConfig _clockConfig;
        private readonly RestClient _restClient;

        public ServerTimeProviderTimeApiIo(ClockConfig clockConfig, RestClient restClient)
        {
            _clockConfig = clockConfig;
            _restClient = restClient;
        }

        public async UniTask<DateTime?> GetCurrentTime()
        {
            var result = await _restClient.Get<TimeApiIoTimeResponse>(_clockConfig.CurrentTimeApiEndpoint);
            if (result.TryGet(out var timeResponse))
            {
                return DateTime.Parse(timeResponse.dateTime);
            }
            return null;
        }
    }
}
