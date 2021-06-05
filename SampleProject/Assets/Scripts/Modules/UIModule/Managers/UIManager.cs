using Modules.CommonModule.Controllers;
using Modules.ResourcesModule.Managers;
using Modules.ScenariosModule.Managers;
using Modules.UIModule.Controllers;
using Modules.UIModule.Enums;
using Modules.UIModule.Views;

namespace Modules.UIModule.Managers
{
    public class UIManager : IUIManager
    {
        private readonly IUIController _uiController;

        public UIManager(
            IResourcesManager resourcesManager,
            CoroutineController coroutineController,
            IScenarioManager scenarioManager)
        {
            _uiController = new UIController(resourcesManager, coroutineController, scenarioManager);
        }

        public void Show<TViewModel>(WindowType windowType, TViewModel viewModel) where TViewModel : IViewModel
        {
            _uiController.ShowWindow(windowType, viewModel);
        }

        public void Hide(WindowType windowType)
        {
            _uiController.HideWindow(windowType);
        }

        public void HideAll()
        {
            _uiController.HideAllWindows();
        }
    }
}