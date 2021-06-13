using System.Collections;
using System.Collections.Generic;
using Modules.CommonModule.Controllers;
using Modules.CommonModule.Logger;
using Modules.GameElementsModule.Providers;
using Modules.GameElementsModule.Views;
using Modules.PoolModule.Manager;
using Modules.ResourcesModule.Managers;
using Modules.UserProfileDataModule.Enums;
using Modules.UserProfileDataModule.Facades;
using UnityEngine;

namespace Modules.GameElementsModule.Facades
{
    public class GameElementFacade : IGameElementFacade
    {
        private readonly IProjectLogger _logger;
        private readonly CoroutineController _coroutineController;
        private readonly IPoolManager _poolManager;
        private readonly IUserProfileDataFacade _userProfileDataFacade;
        private readonly Camera _mainCamera;
        private readonly GameElementsDataProvider _gameElementsDataProvider;

        private const string ModuleResourcesPath = "Configs/GameElementsModule";
        
        private Coroutine _spawnCoinsCoroutine;
        private List<CoinView> _coins;
        
        public GameElementFacade(
            IProjectLogger logger,
            IResourcesManager resourcesManager,
            CoroutineController coroutineController,
            IPoolManager poolManager,
            IUserProfileDataFacade userProfileDataFacade,
            Camera mainCamera)
        {
            _logger = logger;
            _coroutineController = coroutineController;
            _poolManager = poolManager;
            _userProfileDataFacade = userProfileDataFacade;
            _mainCamera = mainCamera;

            _gameElementsDataProvider = resourcesManager.Load<GameElementsDataProvider>($"{ModuleResourcesPath}/GameElementsDataConfig");
            
            _coins = new List<CoinView>();
        }

        public void Start()
        {
            _spawnCoinsCoroutine = _coroutineController.StartCoroutine(SpawnCoinsCoroutine());
            
            _logger.Log(this, "Start spawning game elements");
        }

        public void Stop()
        {
            if (_spawnCoinsCoroutine != null)
            {
                _coroutineController.StopCoroutine(_spawnCoinsCoroutine);
            }
            DestroyCoins();

            _logger.Log(this, "Stop spawning game elements");
        }

        private IEnumerator SpawnCoinsCoroutine()
        {
            var timeStep = 0.5f;
            var count = 30;
            var currentCount = 0;
            while (true)
            {
                if (currentCount < count)
                {
                    var instance = _poolManager.Instantiate(_gameElementsDataProvider.CoinPrefab.gameObject);
                    var coinView = instance.GetComponent<CoinView>();
                    coinView.Initialize(new CoinViewModel(UserProfileDataType.Coins, this));
                    _coins.Add(coinView);
                    instance.transform.position = _mainCamera.ViewportToWorldPoint(new Vector3(Random.value, Random.value, -_mainCamera.transform.position.z));
                    currentCount++;
                }
                yield return new WaitForSeconds(timeStep);
            }
        }

        private void DestroyCoins()
        {
            foreach (var coinView in _coins)
            {
                _poolManager.Destroy(coinView.gameObject);
            }
            _coins.Clear();
        }

        public void DestroyCoin(CoinView coinView)
        {
            _coins.Remove(coinView);
            _poolManager.Destroy(coinView.gameObject);
            _userProfileDataFacade.Add(UserProfileDataType.Coins, 1);
        }
    }
}