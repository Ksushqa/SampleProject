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
        
        private const int Constraint = 20;

        public PoolContainer(GameObject prefab)
        {
            _prefab = prefab;
        }

        public GameObject Instantiate()
        {
            if (_inactiveInstances.Count == 0)
            {
                var instance = Object.Instantiate(_prefab);
                _activeInstances.Add(instance);
                return instance;
            }
            else
            {
                var instance = _inactiveInstances[0];
                instance.SetActive(true);
                _activeInstances.Add(instance);
                _inactiveInstances.Remove(instance);
                return instance;
            }
        }

        public void Destroy(GameObject instance)
        {
            if (!_activeInstances.Contains(instance))
            {
                throw new Exception();
            }
            
            if (_inactiveInstances.Count >= Constraint)
            {
                _activeInstances.Remove(instance);
                Object.Destroy(instance);
            }
            else
            {
                instance.SetActive(false);
                Object.DontDestroyOnLoad(instance);
                _activeInstances.Remove(instance);
                _inactiveInstances.Add(instance);                
            }            
        }
    }
}