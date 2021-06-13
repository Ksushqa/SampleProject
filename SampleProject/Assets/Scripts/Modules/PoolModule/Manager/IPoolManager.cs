using UnityEngine;

namespace Modules.PoolModule.Manager
{
    public interface IPoolManager
    {
        GameObject Instantiate(GameObject prefab);
        void Destroy(GameObject prefab);
    }
}