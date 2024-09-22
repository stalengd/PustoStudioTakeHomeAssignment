using System;
using Cysharp.Threading.Tasks;

namespace PustoStudio.ClockApp.Clock.ServerTime
{
    public interface IServerTimeProvider
    {
        UniTask<DateTime?> GetCurrentTime();
    }
}
