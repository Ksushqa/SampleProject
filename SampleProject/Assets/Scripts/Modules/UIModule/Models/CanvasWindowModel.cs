using Modules.UIModule.Enums;
using UnityEngine;

namespace Modules.UIModule.Models
{
    public class CanvasWindowModel
    {
        public WindowType WindowType { get; }
        public GameObject Canvas { get; }
        public GameObject Window { get; }

        public CanvasWindowModel(WindowType windowType, GameObject canvas, GameObject window)
        {
            WindowType = windowType;
            Canvas = canvas;
            Window = window;
        }
    }
}