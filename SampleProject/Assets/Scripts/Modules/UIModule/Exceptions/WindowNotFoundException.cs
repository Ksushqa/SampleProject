using System;

namespace Modules.UIModule.Exceptions
{
    public class WindowNotFoundException : Exception
    {
        public WindowNotFoundException(string windowType) : base($"Window with type '{windowType}' not found.")
        {
        }
    }
}