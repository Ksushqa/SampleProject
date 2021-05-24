using System;

namespace Modules.ExceptionsModule.UIModuleExceptions
{
    public class WindowNotFoundException : Exception
    {
        public WindowNotFoundException(string windowType) : base($"Window with type '{windowType}' not found.")
        {
        }
    }
}