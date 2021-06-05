using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Managers;
using Modules.UIModule.Enums;
using Modules.UIModule.Managers;
using Modules.UIModule.Views.GameWindow;
using Modules.UIModule.Views.MainWindow;
using Modules.UserProfileDataModule.Facades;

namespace Modules.ScenariosModule.Scenarios
{
    public class MainWindowScenario : BaseScenario
    {
        public override WindowType WindowType => WindowType.Main;

        private readonly IScenarioManager _scenarioManager;
        private readonly IUIManager _uiManager;
        private readonly IUserProfileDataFacade _userProfileDataFacade;

        public MainWindowScenario(
            IScenarioManager scenarioManager,
            IUIManager uiManager,
            IUserProfileDataFacade userProfileDataFacade) : base(scenarioManager, uiManager)
        {
            _scenarioManager = scenarioManager;
            _uiManager = uiManager;
            _userProfileDataFacade = userProfileDataFacade;
        }
        
        public override void InitializeActionsToStorage()
        {
            AddAction(GameActionType.GameInitialized, args =>
            {
                ShowWindowOver(WindowType.Main, new MainWindowViewModel());
            });
            
            AddAction(GameActionType.StartGameButtonPressed, args =>
            {
                HideWindow();
                ShowWindowOver(WindowType.Game, new GameWindowViewModel(_userProfileDataFacade));
            });
        }
    }
}