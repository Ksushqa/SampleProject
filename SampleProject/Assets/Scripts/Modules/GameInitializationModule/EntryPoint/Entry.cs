using Modules.CommonModule.Controllers;
using Modules.ResourcesModule.Managers;
using Modules.SaveModule.Managers;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Managers;
using Modules.ScenariosModule.Scenarios;
using Modules.UIModule.Managers;
using Modules.UserProfileDataModule.Facades;
using UnityEngine;

namespace Modules.GameInitializationModule.EntryPoint
{
    public class Entry : MonoBehaviour
    {
        private void Start()
        {
            IResourcesManager resourcesManager = new ResourcesManager();
            
            var coroutineControllerPrefab = resourcesManager.Load<CoroutineController>("Services/CoroutineController");
            var coroutineController = Instantiate(coroutineControllerPrefab);
            
            ISaveManager saveManager = new SaveManager();
            IScenarioManager scenarioManager = new ScenarioManager(saveManager);
            IUIManager uiManager = new UIManager(resourcesManager, coroutineController, scenarioManager);
            IUserProfileDataFacade userProfileDataFacade = new UserProfileDataFacade();
            
            saveManager.Register(userProfileDataFacade);
            saveManager.LoadState();
            
            var mainWindowScenario = new MainWindowScenario(scenarioManager, uiManager, userProfileDataFacade);
            var gameWindowScenario = new GameWindowScenario(scenarioManager, uiManager);
            
            mainWindowScenario.InitializeActionsToStorage();
            gameWindowScenario.InitializeActionsToStorage();
            
            scenarioManager.ExecuteAction(GameActionType.GameInitialized);
        }
    }
}
