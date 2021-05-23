using UnityEngine;

namespace Modules.ResourcesModule.Managers
{
    public class ResourcesManager : IResourcesManager
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}