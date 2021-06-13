using System.Collections.Generic;
using Modules.PoolModule.Exceptions;
using UnityEngine;

namespace Modules.PoolModule.Controllers
{   
    public class InstancesStorage : IInstancesStorage
    {
        private Dictionary<GameObject, GameObject> _instances = new Dictionary<GameObject, GameObject>();

        public GameObject GetPrefab(GameObject instance)
        {
            if (!_instances.ContainsKey(instance))
            {
                throw new InstanceNotFoundInPoolException(instance.name);
            }
            
            return _instances[instance];
        }

        public void AddInstance(GameObject instance, GameObject prefab)
        {
            _instances.Add(instance, prefab);
        }

        public bool ContainsInstance(GameObject instance)
        {
            return _instances.ContainsKey(instance);
        }

        public void RemoveInstance(GameObject instance)
        {
            _instances.Remove(instance);
        }
    }
}