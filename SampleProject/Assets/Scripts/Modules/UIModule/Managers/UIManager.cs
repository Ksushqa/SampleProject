using Modules.ResourcesModule.Managers;
using Modules.ResourcesModule.Providers;
using Modules.UIModule.Providers;

namespace Modules.UIModule.Managers
{
    public class UIManager : IUIManager
    {
        private const string ModuleResourcesPath = "Configs/UIModule/";
        
        private readonly IResourcesManager _resourcesManager;
        private readonly IWindowsProvider _windowsProvider;
        private readonly ICanvasesProvider _canvasesProvider;
        private readonly IWindowViewProvider _windowViewProvider;
        private readonly ResourcesCollection _canvasesCollection;
        private readonly ResourcesCollection _windowsCollection;

        public UIManager(IResourcesManager resourcesManager)
        {
            _resourcesManager = resourcesManager;

            _canvasesProvider = _resourcesManager.Load<CanvasesProvider>($"{ModuleResourcesPath}/CanvasesConfig");
            _windowsProvider = _resourcesManager.Load<WindowsProvider>($"{ModuleResourcesPath}/WindowsConfig");
            _canvasesCollection = _resourcesManager.Load<ResourcesCollection>($"{ModuleResourcesPath}/CanvasesCollection");
            _windowsCollection = _resourcesManager.Load<ResourcesCollection>($"{ModuleResourcesPath}/CanvasesCollection");
            
            _windowViewProvider = new WindowViewProvider(_canvasesProvider, _windowsProvider, _canvasesCollection, _windowsCollection);
        }
    }
}