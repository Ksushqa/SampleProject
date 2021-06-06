using Modules.CommonModule.Controllers;
using Modules.CommonModule.Logger;
using Modules.GameElementsModule.Facades;
using Modules.PlayerModule.Facades;
using Modules.PoolModule.Manager;
using Modules.ResourcesModule.Managers;
using Modules.SaveModule.Managers;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Managers;
using Modules.ScenariosModule.Scenarios;
using Modules.UIModule.Managers;
using Modules.UserProfileDataModule.Facades;
using Modules.WorldModule.Facades;
using UnityEngine;

namespace Modules.GameInitializationModule.EntryPoint
{
    public class Entry : MonoBehaviour
    {      
        private void Start()
        {
            IProjectLogger logger =
#if UNITY_EDITOR
                new ProjectLogger();
#else
                new FakeLogger();
#endif
            
            IResourcesManager resourcesManager = new ResourcesManager();
            
            var coroutineControllerPrefab = resourcesManager.Load<CoroutineController>("Services/CoroutineController");
            var coroutineController = Instantiate(coroutineControllerPrefab);
            
            IPoolManager poolManager = new PoolManager();
            ISaveManager saveManager = new SaveManager();
            IScenarioManager scenarioManager = new ScenarioManager(saveManager);
            IUIManager uiManager = new UIManager(resourcesManager, coroutineController, scenarioManager);
            IUserProfileDataFacade userProfileDataFacade = new UserProfileDataFacade();
            IPlayerFacade playerFacade = new PlayerFacade(logger, resourcesManager);
            IGameElementFacade gameElementFacade = new GameElementFacade(logger);
            IWorldFacade worldFacade = new WorldFacade(logger, playerFacade, gameElementFacade);
            
            saveManager.Register(userProfileDataFacade);
            saveManager.LoadState();
            
            var mainWindowScenario = new MainWindowScenario(scenarioManager, uiManager, userProfileDataFacade, worldFacade);
            var gameWindowScenario = new GameWindowScenario(scenarioManager, uiManager, worldFacade);
            
            mainWindowScenario.InitializeActionsToStorage();
            gameWindowScenario.InitializeActionsToStorage();
            
            scenarioManager.ExecuteAction(GameActionType.GameInitialized);
        }
    }
}
