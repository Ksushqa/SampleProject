using System;

namespace Modules.ExceptionsModule.ResourcesModuleExceptions
{
    public class IncorrectResourceTypeException : Exception
    {
        public IncorrectResourceTypeException(string type) : base($"Can not load resource by type '{type}' from collection.")
        {
        }
    }
}