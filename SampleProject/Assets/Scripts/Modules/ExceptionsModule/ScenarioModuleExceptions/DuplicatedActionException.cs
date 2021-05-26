using System;

namespace Modules.ExceptionsModule.ScenarioModuleExceptions
{
    public class DuplicatedActionException : Exception
    {
        public DuplicatedActionException(string actionType) : base($"Action storage already contains action key '{actionType}'")
        {
        }
    }
}