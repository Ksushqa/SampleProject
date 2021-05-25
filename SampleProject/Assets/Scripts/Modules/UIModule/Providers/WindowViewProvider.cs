using System.Collections.Generic;
using Modules.ResourcesModule.Providers;
using Modules.UIModule.Enums;
using Modules.UIModule.Models;
using UnityEngine;

namespace Modules.UIModule.Providers
{
    public class WindowViewProvider : IWindowViewProvider
    {
        private readonly Dictionary<WindowType, CanvasWindowModel> _windows;
        
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
            
            _windows = new Dictionary<WindowType, CanvasWindowModel>();
        }

        public CanvasWindowModel GetOrAddWindow(WindowType windowType)
        {
            if (_windows.ContainsKey(windowType))
            {
                return _windows[windowType];
            }
            
            var windowModel = Instantiate(windowType);
            _windows.Add(windowType, windowModel);

            return windowModel;
        }

        private CanvasWindowModel Instantiate(WindowType windowType)
        {
            var windowModel = _windowsProvider.GetWindowModel(windowType);
            var windowPrefab = _windowsCollection.Load<GameObject>(windowModel.Id);
            var canvasId = _canvasesProvider.GetId(windowModel.Canvas);
            var canvasPrefab = _canvasesCollection.Load<GameObject>(canvasId);

            var canvasInstance = Object.Instantiate(canvasPrefab);
            var windowInstance = Object.Instantiate(windowPrefab, canvasInstance.transform);
            
            return new CanvasWindowModel(windowType, canvasInstance, windowInstance);
        }

        public bool RemoveWindow(WindowType windowType)
        {
            if (_windows.ContainsKey(windowType))
            {
                var windowModel = _windows[windowType];
                Object.Destroy(windowModel.Canvas);
                _windows.Remove(windowType);
                return true;
            }

            return false;
        }
    }
}