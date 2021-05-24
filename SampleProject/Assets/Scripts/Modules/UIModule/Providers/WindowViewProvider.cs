using Modules.ResourcesModule.Providers;
using Modules.UIModule.Enums;
using Modules.UIModule.Models;
using Modules.UIModule.Views;
using UnityEngine;

namespace Modules.UIModule.Providers
{
    public class WindowViewProvider : IWindowViewProvider
    {
        private readonly ICanvasesProvider _canvasesProvider;
        private readonly IWindowsProvider _windowsProvider;
        private readonly IResourcesCollection _canvasesCollection;
        private readonly IResourcesCollection _windowsCollection;

        public WindowViewProvider(
            ICanvasesProvider canvasesProvider,
            IWindowsProvider windowsProvider,
            IResourcesCollection canvasesCollection,
            IResourcesCollection windowsCollection)
        {
            _canvasesProvider = canvasesProvider;
            _windowsProvider = windowsProvider;
            _canvasesCollection = canvasesCollection;
            _windowsCollection = windowsCollection;
        }

        public CanvasWindowModel GetWindow(WindowType windowType)
        {
            var windowModel = _windowsProvider.GetWindowModel(windowType);
            var windowPrefab = _windowsCollection.Load<GameObject>(windowModel.Id);
            var canvasId = _canvasesProvider.GetId(windowModel.Canvas);
            var canvasPrefab = _canvasesCollection.Load<CanvasView>(canvasId);

            var canvasInstance = Object.Instantiate(canvasPrefab);
            var windowInstance = Object.Instantiate(windowPrefab, canvasInstance.Content);
            
            return new CanvasWindowModel(windowType, canvasInstance, windowInstance);
        }
    }
}