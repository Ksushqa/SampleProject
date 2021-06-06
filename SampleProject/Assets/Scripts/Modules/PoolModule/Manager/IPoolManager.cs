using UnityEngine;

namespace Modules.PoolModule.Manager
{
    public interface IPoolManager
    {
        void SetConstraint(GameObject prefab, int constraint);
        GameObject Instantiate(GameObject prefab);
        void Destroy(GameObject prefab);
    }
}