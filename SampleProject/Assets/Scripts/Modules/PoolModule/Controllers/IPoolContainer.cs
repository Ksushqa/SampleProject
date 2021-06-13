using UnityEngine;

namespace Modules.PoolModule.Controllers
{
    public interface IPoolContainer
    {
        GameObject Instantiate();
        void Destroy(GameObject instance);
    }
}