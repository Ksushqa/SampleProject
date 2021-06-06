using Modules.CommonModule.Logger;

namespace Modules.GameElementsModule.Facades
{
    public class GameElementFacade : IGameElementFacade
    {
        private readonly IProjectLogger _logger;

        public GameElementFacade(IProjectLogger logger)
        {
            _logger = logger;
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