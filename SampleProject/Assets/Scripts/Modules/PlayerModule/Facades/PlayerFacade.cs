using Modules.PlayerModule.Views;

namespace Modules.PlayerModule.Facades
{
    public class PlayerFacade : IPlayerFacade
    {
        public PlayerView Player { get; }

        private PlayerView _player;
        
        public void Create()
        {
            
        }

        public void Destroy()
        {
            
        }
    }
}