using Modules.SaveModule.Interfaces;

namespace Modules.UserProfileDataModule.Controllers
{
    public interface IUserProfileDataController : ISavable
    {
        int Get();
        void Add(int amount);
        void Reset();
    }
}