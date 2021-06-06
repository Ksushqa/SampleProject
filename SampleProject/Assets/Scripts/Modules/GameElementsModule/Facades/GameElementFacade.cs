using Modules.CommonModule.Controllers;
using Modules.CommonModule.Logger;
using Modules.GameElementsModule.Providers;
using Modules.ResourcesModule.Managers;

namespace Modules.GameElementsModule.Facades
{
    public class GameElementFacade : IGameElementFacade
    {
        private readonly IProjectLogger _logger;
        private readonly CoroutineController _coroutineController;
        private GameElementsDataProvider _gameElementsDataProvider;

        private const string ModuleResourcesPath = "Configs/GameElementModule";

        public GameElementFacade(
            IProjectLogger logger,
            IResourcesManager resourcesManager,
            CoroutineController coroutineController)
        {
            _logger = logger;
            _coroutineController = coroutineController;
            _gameElementsDataProvider = resourcesManager.Load<GameElementsDataProvider>($"{ModuleResourcesPath}/GameElementsDataConfig");
        }

        public void Start()
        {
            _logger.Log(this, "Start spawning game elements");
        }

        public void Stop()
        {
            _logger.Log(this, "Stop spawning game elements");
        }
    }
}