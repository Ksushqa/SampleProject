using UnityEngine;

namespace Modules.PoolModule.Controllers
{
    public interface IInstancesStorage
    {
        GameObject GetPrefab(GameObject instance);
        void AddInstance(GameObject instance, GameObject prefab);
        bool ContainsInstance(GameObject instance);
        void RemoveInstance(GameObject instance);
    }
}