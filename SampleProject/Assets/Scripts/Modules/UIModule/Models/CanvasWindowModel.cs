using Modules.UIModule.Enums;
using Modules.UIModule.Views;
using UnityEngine;

namespace Modules.UIModule.Models
{
    public class CanvasWindowModel
    {
        public WindowType WindowType { get; }
        public GameObject Canvas { get; }
        public BaseWindowView Window { get; }

        public CanvasWindowModel(WindowType windowType, GameObject canvas, BaseWindowView window)
        {
            WindowType = windowType;
            Canvas = canvas;
            Window = window;
        }
    }
}