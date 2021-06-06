using UnityEngine;

namespace Modules.PoolModule.Controllers
{
    public interface IPoolContainer
    {
        void SetConstraint(int constraint);
        GameObject Instantiate();
        void Destroy(GameObject instance);
    }
}