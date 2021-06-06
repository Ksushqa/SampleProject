using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Managers;
using Modules.UIModule.Enums;
using Modules.UIModule.Managers;
using Modules.UIModule.Views.MainWindow;
using Modules.WorldModule.Facades;

namespace Modules.ScenariosModule.Scenarios
{
    public class GameWindowScenario : BaseScenario
    {
        private readonly IWorldFacade _worldFacade;
        public override WindowType WindowType => WindowType.Game;

        public GameWindowScenario(
            IScenarioManager scenarioManager,
            IUIManager uiManager,
            IWorldFacade worldFacade) : base(scenarioManager, uiManager)
        {
            _worldFacade = worldFacade;
        }

        public override void InitializeActionsToStorage()
        {
            AddAction(GameActionType.BackToMainMenuPressed, args =>
            {
                HideWindow();
                ShowWindowOver(WindowType.Main, new MainWindowViewModel());
                _worldFacade.Stop();
            });
        }
    }
}