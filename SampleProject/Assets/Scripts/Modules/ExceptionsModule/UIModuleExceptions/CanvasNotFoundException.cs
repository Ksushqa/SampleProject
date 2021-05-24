using System;

namespace Modules.ExceptionsModule.UIModuleExceptions
{
    public class CanvasNotFoundException : Exception
    {
        public CanvasNotFoundException(string canvasType) : base($"Canvas with type '{canvasType}' not found.")
        {
        }
    }
}