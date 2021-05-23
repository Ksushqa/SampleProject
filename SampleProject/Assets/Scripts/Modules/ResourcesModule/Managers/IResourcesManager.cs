using Modules.ResourcesModule.Enums;
using UnityEngine;

namespace Modules.ResourcesModule.Managers
{
    public interface IResourcesManager
    {
        T Load<T>(string path) where T : Object;
        T Load<T>(string path, ResourcesCategory resources) where T : Object;
    }
}