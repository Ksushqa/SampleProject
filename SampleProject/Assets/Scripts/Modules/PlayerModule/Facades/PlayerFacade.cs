using Modules.CommonModule.Controllers;
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
        private readonly Camera _mainCamera;
        private readonly MouseUserActionController _mouseUserActionController;
        public PlayerView Player { get; }

        private const string ModuleResourcesPath = "Configs/PlayerModule";
        
        private PlayerView _player;

        private readonly PlayerDataProvider _playerDataProvider;

        public PlayerFacade(IProjectLogger logger,
            Camera mainCamera,
            IResourcesManager resourcesManager,
            MouseUserActionController mouseUserActionController)
        {
            _logger = logger;
            _mainCamera = mainCamera;
            _mouseUserActionController = mouseUserActionController;
            _playerDataProvider = resourcesManager.Load<PlayerDataProvider>($"{ModuleResourcesPath}/PlayerDataConfig");
        }

        public void Create()
        {
            _player = Object.Instantiate(_playerDataProvider.PlayerPrefab);
            _player.Initialize(new PlayerViewModel(_mainCamera, _mouseUserActionController, _playerDataProvider.Speed));
            _logger.Log(this, "Instantiate player");
        }

        public void Destroy()
        {
            Object.Destroy(_player.gameObject);
            _logger.Log(this, "Destroy player");
        }
    }
}