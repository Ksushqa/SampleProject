using System;

namespace Modules.PoolModule.Exceptions
{
    public class InstanceNotFoundInPoolException : Exception
    {
        public InstanceNotFoundInPoolException(string instanceName) : base($"Instance '{instanceName}' was not found in pool.")
        {
        }
    }
}