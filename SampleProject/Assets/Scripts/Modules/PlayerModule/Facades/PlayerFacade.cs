using Modules.CommonModule.Logger;
using Modules.PlayerModule.Providers;
using Modules.PlayerModule.Views;
using Modules.ResourcesModule.Managers;
using UnityEngine;

namespace Modules.PlayerModule.Facades
{
    public class PlayerFacade : IPlayerFacade
    {
        private readonly IProjectLogger _logger;
        public PlayerView Player { get; }

        private const string ModuleResourcesPath = "Configs/PlayerModule";
        
        private PlayerView _player;

        private readonly PlayerDataProvider _playerDataProvider;

        public PlayerFacade(IProjectLogger logger, IResourcesManager resourcesManager)
        {
            _logger = logger;
            _playerDataProvider = resourcesManager.Load<PlayerDataProvider>($"{ModuleResourcesPath}/PlayerDataConfig");
        }

        public void Create()
        {
            _player = Object.Instantiate(_playerDataProvider.PlayerPrefab);
            _logger.Log(this, "Instantiate player");
        }

        public void Destroy()
        {
            Object.Destroy(_player.gameObject);
            _logger.Log(this, "Destroy player");
        }
    }
}