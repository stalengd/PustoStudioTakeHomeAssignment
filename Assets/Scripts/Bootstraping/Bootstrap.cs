using Cysharp.Threading.Tasks;

using PustoStudio.ClockApp.Clock.Model;

using UnityEngine.SceneManagement;

using Zenject;

namespace PustoStudio.ClockApp.Bootstraping
{
    public sealed class Bootstrap : IInitializable
    {
        private readonly ClockService _clockService;

        public Bootstrap(ClockService clockService)
        {
            _clockService = clockService;
        }

        public void Initialize()
        {
            Load().Forget();
        }

        private async UniTask Load()
        {
            await _clockService.Initialize();

            SceneManager.LoadScene("Main");
        }
    }
}
