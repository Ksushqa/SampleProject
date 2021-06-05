using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Managers;
using Modules.UIModule.Enums;
using Modules.UIModule.Managers;
using Modules.UIModule.Views.MainWindow;

namespace Modules.ScenariosModule.Scenarios
{
    public class GameWindowScenario : BaseScenario
    {
        public override WindowType WindowType => WindowType.Game;

        public GameWindowScenario(IScenarioManager scenarioManager, IUIManager uiManager) : base(scenarioManager, uiManager)
        {
        }

        public override void InitializeActionsToStorage()
        {
            AddAction(GameActionType.BackToMainMenuPressed, args =>
            {
                ShowWindowUnique(WindowType.Main, new MainWindowViewModel());
            });
        }
    }
}