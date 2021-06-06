using System;

namespace Modules.ResourcesModule.Exceptions
{
    public class IncorrectResourceIdException : Exception
    {
        public IncorrectResourceIdException(string resourceId) : base($"There is no resource with resource id '{resourceId}' in collection.")
        {
        }
    }
}