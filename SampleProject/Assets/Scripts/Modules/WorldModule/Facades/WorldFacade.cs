using Modules.CommonModule.Logger;
using Modules.GameElementsModule.Facades;
using Modules.PlayerModule.Facades;

namespace Modules.WorldModule.Facades
{
    public class WorldFacade : IWorldFacade
    {
        private readonly IProjectLogger _logger;
        private readonly IPlayerFacade _playerFacade;
        private readonly IGameElementFacade _gameElementFacade;

        public WorldFacade(IProjectLogger logger, IPlayerFacade playerFacade, IGameElementFacade gameElementFacade)
        {
            _logger = logger;
            _playerFacade = playerFacade;
            _gameElementFacade = gameElementFacade;
        }

        public void Start()
        {
            _logger.Log(this, "Create world");
            _playerFacade.Create();
            _gameElementFacade.Start();
        }

        public void Stop()
        {
            _logger.Log(this, "Destroy world");
            _playerFacade.Destroy();
            _gameElementFacade.Stop();
        }
    }
}