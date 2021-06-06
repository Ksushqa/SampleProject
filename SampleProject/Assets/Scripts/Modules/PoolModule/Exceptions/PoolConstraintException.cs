using System;

namespace Modules.PoolModule.Exceptions
{
    public class PoolConstraintException : Exception
    {
        public PoolConstraintException() : base("Can not set constraint after first prefab instantiation.")
        {
        }
    }
}