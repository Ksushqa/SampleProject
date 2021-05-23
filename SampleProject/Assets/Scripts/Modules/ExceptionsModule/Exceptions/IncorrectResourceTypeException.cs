using System;

namespace Modules.ExceptionsModule.Exceptions
{
    public class IncorrectResourceTypeException : Exception
    {
        public IncorrectResourceTypeException(string type) : base($"Can not load resource by type '{type}' from collection.")
        {
        }
    }
}