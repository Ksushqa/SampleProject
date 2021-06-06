using System;

namespace Modules.UIModule.Exceptions
{
    public class CanvasNotFoundException : Exception
    {
        public CanvasNotFoundException(string canvasType) : base($"Canvas with type '{canvasType}' not found.")
        {
        }
    }
}