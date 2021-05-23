using System;

namespace Modules.ExceptionsModule.Exceptions
{
    public class IncorrectResourceIdException : Exception
    {
        public IncorrectResourceIdException(string resourceId) : base($"There is no resource with {resourceId} in collection.")
        {
        }
    }
}