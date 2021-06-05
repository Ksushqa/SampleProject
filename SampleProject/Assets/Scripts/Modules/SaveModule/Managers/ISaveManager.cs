using Modules.SaveModule.Interfaces;

namespace Modules.SaveModule.Managers
{
    public interface ISaveManager
    {
        void Register(ISavable savableItem);
        void Unregister(ISavable savableItem);
        void SaveState();
        void LoadState();
    }
}