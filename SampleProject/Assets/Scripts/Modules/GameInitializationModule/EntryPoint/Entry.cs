using Modules.CommonModule.Controllers;
using Modules.ResourcesModule.Managers;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Managers;
using Modules.ScenariosModule.Scenarios;
using Modules.UIModule.Managers;
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
            
            IScenarioManager scenarioManager = new ScenarioManager();
            IUIManager uiManager = new UIManager(resourcesManager, coroutineController, scenarioManager);

            var mainWindowScenario = new MainWindowScenario(scenarioManager, uiManager);
            var gameWindowScenario = new GameWindowScenario(scenarioManager, uiManager);
            
            mainWindowScenario.InitializeActionsToStorage();
            gameWindowScenario.InitializeActionsToStorage();
            
            scenarioManager.ExecuteAction(GameActionType.GameInitialized);
        }
    }
}
