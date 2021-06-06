using System;

namespace Modules.ScenariosModule.Exceptions
{
    public class DuplicatedActionException : Exception
    {
        public DuplicatedActionException(string actionType) : base($"Action storage already contains action key '{actionType}'")
        {
        }
    }
}