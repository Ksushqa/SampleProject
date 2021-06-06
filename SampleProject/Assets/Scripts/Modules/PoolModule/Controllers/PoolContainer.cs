using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Modules.PoolModule.Controllers
{
    public class PoolContainer : IPoolContainer
    {
        private readonly List<GameObject> _activeInstances = new List<GameObject>();
        private readonly List<GameObject> _inactiveInstances = new List<GameObject>();

        private readonly GameObject _prefab;
        private int _constraint = 20;

        public PoolContainer(GameObject prefab)
        {
            _prefab = prefab;
        }

        public GameObject Instantiate()
        {
            var instance = Object.Instantiate(_prefab);
            _activeInstances.Add(instance);

            return instance;
        }

        public void Destroy(GameObject instance)
        {
            if (!_activeInstances.Contains(instance))
            {
                throw new Exception();
            }
            
            _activeInstances.Remove(instance);

            if (_activeInstances.Count + _inactiveInstances.Count >= _constraint)
            {
                Object.Destroy(instance);
            }
            else
            {
                instance.SetActive(false);
                _inactiveInstances.Add(instance);                
            }            
        }

        public void SetConstraint(int constraint)
        {
            _constraint = constraint;
        }
    }
}