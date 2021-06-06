using System;

namespace Modules.ResourcesModule.Exceptions
{
    public class IncorrectResourceTypeException : Exception
    {
        public IncorrectResourceTypeException(string type) : base($"Can not load resource by type '{type}' from collection.")
        {
        }
    }
}