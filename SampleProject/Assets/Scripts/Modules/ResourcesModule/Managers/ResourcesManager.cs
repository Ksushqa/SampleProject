using Modules.ResourcesModule.Enums;
using UnityEngine;

namespace Modules.ResourcesModule.Managers
{
    public class ResourcesManager : IResourcesManager
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public T Load<T>(string path, ResourcesCategory resources) where T : Object
        {
            var collectionPath = resources != ResourcesCategory.None ? $"{resources.ToString()}/" : string.Empty;
            var resourcePath = $"{collectionPath}{path}";
            return Resources.Load<T>(resourcePath);
        }
    }
}