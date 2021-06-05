using Modules.PlayerModule.Facades;

namespace Modules.WorldModule.Facades
{
    public class WorldFacade : IWorldFacade
    {
        private readonly IPlayerFacade _playerFacade;

        public WorldFacade(IPlayerFacade playerFacade)
        {
            _playerFacade = playerFacade;
        }

        public void Start()
        {
            _playerFacade.Create();
        }

        public void Stop()
        {
            _playerFacade.Destroy();
        }
    }
}