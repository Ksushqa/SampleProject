using Modules.ResourcesModule.Managers;
using Modules.ResourcesModule.Providers;
using Modules.UIModule.Enums;
using Modules.UIModule.Providers;
using Modules.UIModule.Views;

namespace Modules.UIModule.Managers
{
    public class UIManager : IUIManager
    {
        private const string ModuleResourcesPath = "Configs/UIModule/";

        private readonly ICanvasesProvider _canvasesProvider;
        private readonly IWindowViewProvider _windowViewProvider;
        private readonly ResourcesCollection _canvasesCollection;
        private readonly ResourcesCollection _windowsCollection;

        public UIManager(IResourcesManager resourcesManager)
        {
            _canvasesProvider = resourcesManager.Load<CanvasesProvider>($"{ModuleResourcesPath}/CanvasesConfig");
            IWindowsProvider windowsProvider = resourcesManager.Load<WindowsProvider>($"{ModuleResourcesPath}/WindowsConfig");
            _canvasesCollection = resourcesManager.Load<ResourcesCollection>($"{ModuleResourcesPath}/CanvasesCollection");
            _windowsCollection = resourcesManager.Load<ResourcesCollection>($"{ModuleResourcesPath}/CanvasesCollection");
            
            _windowViewProvider = new WindowViewProvider(_canvasesProvider, windowsProvider, _canvasesCollection, _windowsCollection);
        }

        public TView ShowWindow<TView, TViewModel>(WindowType windowType, TViewModel viewModel)
            where TView : IBaseView<TViewModel>
            where TViewModel : IViewModel
        {
            var windowModel = _windowViewProvider.GetOrAddWindow(windowType);
            var windowView = windowModel.Window.GetComponent<TView>();
            windowView.Initialize(viewModel);

            return windowView;
        }

        public bool HideWindow(WindowType windowType)
        {
            return _windowViewProvider.RemoveWindow(windowType);
        }
    }
}