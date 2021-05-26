using System.Collections;
using System.Collections.Generic;
using Modules.CommonModule.Controllers;
using Modules.ResourcesModule.Models;
using Modules.ResourcesModule.Providers;
using Modules.UIModule.Enums;
using Modules.UIModule.Models;
using Modules.UIModule.Views;
using UnityEngine;

namespace Modules.UIModule.Providers
{
    public class WindowViewProvider : IWindowViewProvider
    {
        private readonly Dictionary<WindowType, CanvasWindowModel> _windows;

        private readonly CoroutineController _coroutineController;
        private readonly ICanvasesProvider _canvasesProvider;
        private readonly IWindowsProvider _windowsProvider;
        private readonly IResourcesCollection _canvasesCollection;
        private readonly IResourcesCollection _windowsCollection;

        public WindowViewProvider(
            CoroutineController coroutineController,
            ICanvasesProvider canvasesProvider,
            IWindowsProvider windowsProvider,
            IResourcesCollection canvasesCollection,
            IResourcesCollection windowsCollection)
        {
            _coroutineController = coroutineController;
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
            var baseWindowView = windowInstance.GetComponent<BaseWindowView>();
            
            return new CanvasWindowModel(windowType, canvasInstance, baseWindowView);
        }

        public bool RemoveWindow(WindowType windowType)
        {
            if (_windows.ContainsKey(windowType))
            {
                var windowModel = _windows[windowType];
                _coroutineController.StartCoroutine(RemoveWindowCoroutine(windowModel));
                return true;
            }

            return false;
        }

        private IEnumerator RemoveWindowCoroutine(CanvasWindowModel windowModel)
        {
            windowModel.Window.PlayDestroy();
            yield return new WaitForSeconds(windowModel.Window.TimeBeforeDestroy);
            Object.Destroy(windowModel.Canvas);
            _windows.Remove(windowModel.WindowType);
        }
    }
}