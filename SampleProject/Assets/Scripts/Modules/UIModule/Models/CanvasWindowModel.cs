using Modules.UIModule.Enums;
using Modules.UIModule.Views;
using UnityEngine;

namespace Modules.UIModule.Models
{
    public class CanvasWindowModel
    {
        public WindowType WindowType { get; }
        public CanvasView Canvas { get; }
        public GameObject Window { get; }

        public CanvasWindowModel(WindowType windowType, CanvasView canvas, GameObject window)
        {
            WindowType = windowType;
            Canvas = canvas;
            Window = window;
        }
    }
}