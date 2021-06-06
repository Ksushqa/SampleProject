using System;

namespace Modules.ScenariosModule.Exceptions
{
    public class NotFoundActionException : Exception
    {
        public NotFoundActionException(string actionType) : base($"Not found action with type '{actionType}'")
        {
        }
    }
}