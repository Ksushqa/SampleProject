using System;

namespace Modules.PoolModule.Exceptions
{
    public class PrefabNotFoundInPoolException : Exception
    {
        public PrefabNotFoundInPoolException(string prefabName) : base($"Prefab '{prefabName}' was not found in pool.")
        {
        }
    }
}