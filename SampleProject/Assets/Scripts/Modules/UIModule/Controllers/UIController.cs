using Modules.CommonModule.Controllers;
using Modules.CommonModule.Views;
using Modules.ResourcesModule.Managers;
using Modules.ResourcesModule.Providers;
using Modules.ScenariosModule.Managers;
using Modules.UIModule.Enums;
using Modules.UIModule.Helpers;
using Modules.UIModule.Providers;

namespace Modules.UIModule.Controllers
{
    public class UIController : IUIController
    {
        private const string ModuleResourcesPath = "Configs/UIModule";

        private readonly ICanvasesProvider _canvasesProvider;
        private readonly IWindowViewProvider _windowViewProvider;
        private readonly ResourcesCollection _canvasesCollection;
        private readonly ResourcesCollection _windowsCollection;
        private readonly WindowsProvider _windowsProvider;

        public UIController(IResourcesManager resourcesManager, CoroutineController coroutineController, IScenarioManager scenarioManager)
        {
            _canvasesProvider = resourcesManager.Load<CanvasesProvider>($"{ModuleResourcesPath}/CanvasesConfig");
            _windowsProvider = resourcesManager.Load<WindowsProvider>($"{ModuleResourcesPath}/WindowsConfig");
            _canvasesCollection = resourcesManager.Load<ResourcesCollection>($"{ModuleResourcesPath}/CanvasesCollection");
            _windowsCollection = resourcesManager.Load<ResourcesCollection>($"{ModuleResourcesPath}/WindowsCollection");
            
            _windowViewProvider = new WindowViewProvider(scenarioManager, coroutineController, _canvasesProvider, _windowsProvider, _canvasesCollection, _windowsCollection);
        }
        
        public void ShowWindow<TViewModel>(WindowType windowType, TViewModel viewModel)
            where TViewModel : IViewModel
        {
            var windowModel = _windowViewProvider.GetOrAddWindow(windowType);
            var viewType = WindowTypeHelper.GetViewType(windowType);
            var windowView = windowModel.Window.GetComponent(viewType);
            var baseView = (BaseUiView<TViewModel>) windowView;
            baseView.Initialize(viewModel);
        }
        
        public bool HideWindow(WindowType windowType)
        {
            return _windowViewProvider.RemoveWindow(windowType);
        }

        public void HideAllWindows()
        {
            _windowViewProvider.RemoveAllWindows();
        }
    }
}