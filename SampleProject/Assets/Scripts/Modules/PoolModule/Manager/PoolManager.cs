using System.Collections.Generic;
using Modules.PoolModule.Controllers;
using Modules.PoolModule.Exceptions;
using UnityEngine;

namespace Modules.PoolModule.Manager
{
    public class PoolManager : IPoolManager
    {
        private readonly IInstancesStorage _instancesStorage;

        private readonly Dictionary<GameObject, IPoolContainer> _containers = new Dictionary<GameObject, IPoolContainer>();

        public PoolManager()
        {
            _instancesStorage = new InstancesStorage();
        }

        public void SetConstraint(GameObject prefab, int constraint)
        {
            if (_containers.ContainsKey(prefab))
            {
                throw new PoolConstraintException();
            }
            
            _containers[prefab].SetConstraint(constraint);
        }
        
        public GameObject Instantiate(GameObject prefab)
        {
            if (!_containers.ContainsKey(prefab))
            {
                _containers.Add(prefab, new PoolContainer(prefab));
            }

            var instance = _containers[prefab].Instantiate();
            _instancesStorage.AddInstance(instance, prefab);
            
            return instance;
        }

        public void Destroy(GameObject instance)
        {
            var prefab = _instancesStorage.GetPrefab(instance);

            if (!_containers.ContainsKey(prefab))
            {
                throw new InstanceNotFoundInPoolException(instance.name);
            }
            
            _containers[prefab].Destroy(instance);
        }
    }
}