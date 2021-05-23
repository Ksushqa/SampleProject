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

        public T Load<T>(string path, ResourcesCategoryType resources) where T : Object
        {
            var collectionPath = resources != ResourcesCategoryType.None ? $"{resources.ToString()}/" : string.Empty;
            var resourcePath = $"Media/{collectionPath}{path}";
            return Resources.Load<T>(resourcePath);
        }
    }
}