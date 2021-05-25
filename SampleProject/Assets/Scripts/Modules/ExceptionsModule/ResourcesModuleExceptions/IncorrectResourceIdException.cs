using System;

namespace Modules.ExceptionsModule.ResourcesModuleExceptions
{
    public class IncorrectResourceIdException : Exception
    {
        public IncorrectResourceIdException(string resourceId) : base($"There is no resource with resource id '{resourceId}' in collection.")
        {
        }
    }
}