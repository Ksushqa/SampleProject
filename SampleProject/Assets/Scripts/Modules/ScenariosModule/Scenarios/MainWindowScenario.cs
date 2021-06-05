using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Managers;
using Modules.UIModule.Enums;
using Modules.UIModule.Managers;
using Modules.UIModule.Views.GameWindow;
using Modules.UIModule.Views.MainWindow;
using UnityEngine;

namespace Modules.ScenariosModule.Scenarios
{
    public class MainWindowScenario : BaseScenario
    {
        public override WindowType WindowType => WindowType.Main;

        private readonly IScenarioManager _scenarioManager;
        private readonly IUIManager _uiManager;

        public MainWindowScenario(IScenarioManager scenarioManager, IUIManager uiManager) : base(scenarioManager, uiManager)
        {
            _scenarioManager = scenarioManager;
            _uiManager = uiManager;
        }
        
        public override void InitializeActionsToStorage()
        {
            AddAction(GameActionType.GameInitialized, args =>
            {
                Debug.Log("GameActionType.GameInitialized");
                ShowWindowOver(WindowType.Main, new MainWindowViewModel());
            });
            
            AddAction(GameActionType.StartGameButtonPressed, args =>
            {
                Debug.Log("GameActionType.StartGameButtonPressed");
                ShowWindowUnique(WindowType.Game, new GameWindowViewModel());
            });
        }
    }
}