using Modules.ResourcesModule.Managers;
using UnityEngine;

public class Entry : MonoBehaviour
{
    private void Start()
    {
        IResourcesManager resourcesManager = new ResourcesManager();
    }
}
