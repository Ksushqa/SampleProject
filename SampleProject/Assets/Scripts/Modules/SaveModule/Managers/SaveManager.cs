using System.Collections.Generic;
using Modules.SaveModule.Interfaces;

namespace Modules.SaveModule.Managers
{
    public class SaveManager : ISaveManager
    {
        private readonly List<ISavable> _savableItems = new List<ISavable>();
        
        public void Register(ISavable savableItem)
        {
            _savableItems.Add(savableItem);
        }

        public void Unregister(ISavable savableItem)
        {
            _savableItems.Remove(savableItem);
        }

        public void SaveState()
        {
            foreach (var savableItem in _savableItems)
            {
                savableItem.Save();
            }
        }

        public void LoadState()
        {
            foreach (var savableItem in _savableItems)
            {
                savableItem.Load();
            }
        }
    }
}