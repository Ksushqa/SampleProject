using UnityEngine;

namespace Modules.ResourcesModule.Providers
{
    public interface IResourcesCollection
    {
        T Load<T>(string id) where T : Object;
    }
}