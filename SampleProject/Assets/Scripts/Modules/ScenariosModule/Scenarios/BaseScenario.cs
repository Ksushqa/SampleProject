using System;
using Modules.CommonModule.Views;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Managers;
using Modules.ScenariosModule.Models;
using Modules.UIModule.Enums;
using Modules.UIModule.Managers;
using Modules.UIModule.Views;

namespace Modules.ScenariosModule.Scenarios
{
    public abstract class BaseScenario
    {
        public abstract WindowType WindowType { get; }
        public abstract void InitializeActionsToStorage();

        private readonly IScenarioManager _scenarioManager;
        private readonly IUIManager _uiManager;

        protected BaseScenario(
            IScenarioManager scenarioManager,
            IUIManager uiManager)
        {
            _scenarioManager = scenarioManager;
            _uiManager = uiManager;
        }

        public void AddAction(GameActionType actionType, Action<GameActionArgs> onActionDone)
        {
            _scenarioManager.RegisterAction(actionType, onActionDone);
        }
        
        public void ShowWindowUnique<TViewModel>(WindowType windowType, TViewModel viewModel) where TViewModel : IViewModel
        {
            _uiManager.HideAll();
            _uiManager.Show(windowType, viewModel);
        }

        public void ShowWindowOver<TViewModel>(WindowType windowType, TViewModel viewModel) where TViewModel : IViewModel
        {
            _uiManager.Show(windowType, viewModel);            
        }

        public void HideWindow()
        {
            _uiManager.Hide(WindowType);
        }
        
        public void HideAllWindows()
        {
            _uiManager.HideAll();
        }
    }
}