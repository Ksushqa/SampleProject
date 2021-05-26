using System;

namespace Modules.ExceptionsModule.ScenarioModuleExceptions
{
    public class NotFoundActionException : Exception
    {
        public NotFoundActionException(string actionType) : base($"Not found action with type '{actionType}'")
        {
        }
    }
}