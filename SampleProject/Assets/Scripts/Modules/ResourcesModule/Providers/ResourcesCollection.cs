using System.Collections.Generic;
using System.Linq;
using Modules.ExceptionsModule.Exceptions.ResourcesModule;
using Modules.ResourcesModule.Models;
using UnityEngine;

namespace Modules.ResourcesModule.Providers
{
    [CreateAssetMenu(fileName = "ResourcesCollection", menuName = "SampleProject/Create ResourcesCollection")]
    public class ResourcesCollection : ScriptableObject, IResourcesCollection
    {
        [SerializeField] private List<ResourceReference> _resources;
        
        public T Load<T>(string id) where T : Object
        {
            var path = GetResourcePath(id);
            var resource = Resources.Load<T>(path);

            if (resource == null)
            {
                throw new IncorrectResourceTypeException(typeof(T).ToString());
            }
            
            return Resources.Load<T>(path);
        }
        
        private string GetResourcePath(string id)
        {
            var resourceReference = _resources.FirstOrDefault(x => x.Id == id);

            if (resourceReference == null)
            {
                throw new IncorrectResourceIdException(id);
            }

            return resourceReference.GetPath();
        }
    }
}