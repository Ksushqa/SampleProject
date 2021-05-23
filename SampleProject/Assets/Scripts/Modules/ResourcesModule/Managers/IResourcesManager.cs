using UnityEngine;

namespace Modules.ResourcesModule.Managers
{
    public interface IResourcesManager
    {
        T Load<T>(string path) where T : Object;
    }
}