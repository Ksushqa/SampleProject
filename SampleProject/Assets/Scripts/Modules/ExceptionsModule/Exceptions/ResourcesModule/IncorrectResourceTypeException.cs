using System;

namespace Modules.ExceptionsModule.Exceptions.ResourcesModule
{
    public class IncorrectResourceTypeException : Exception
    {
        public IncorrectResourceTypeException(string type) : base($"Can not load resource by type '{type}' from collection.")
        {
        }
    }
}