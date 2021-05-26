using Modules.CommonModule.Controllers;
using Modules.ResourcesModule.Managers;
using Modules.ScenariosModule.Managers;
using Modules.UIModule.Controllers;
using Modules.UIModule.Enums;
using Modules.UIModule.Views;
using Modules.UIModule.Views.MainWindow;

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

        public void Show<TView, TViewModel>(WindowType windowType, TViewModel viewModel)
            where TView : IBaseView<TViewModel>
            where TViewModel : IViewModel
        {
            _uiController.ShowWindow<TView, TViewModel>(windowType, viewModel);
        }

        public void Show<TViewModel>(WindowType windowType, TViewModel viewModel) where TViewModel : IViewModel
        {
            _uiController.ShowWindow(windowType, viewModel);
        }

        public void Hide(WindowType windowType)
        {
            
        }

        public void HideAll()
        {
            
        }
    }
}