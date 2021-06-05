using System;
using System.Collections.Generic;
using Modules.UserProfileDataModule.Controllers;
using Modules.UserProfileDataModule.Enums;
using Modules.UserProfileDataModule.Models;

namespace Modules.UserProfileDataModule.Facades
{
    public class UserProfileDataFacade : IUserProfileDataFacade
    {
        public event EventHandler<UserProfileDataChangedArgs> Changed;

        private readonly Dictionary<UserProfileDataType, IUserProfileDataController> _profileControllers = new Dictionary<UserProfileDataType, IUserProfileDataController>();
        
        public UserProfileDataFacade()
        {
            _profileControllers.Add(UserProfileDataType.Coins, new UserProfileDataController(UserProfileDataType.Coins));
            _profileControllers.Add(UserProfileDataType.Energy, new UserProfileDataController(UserProfileDataType.Energy));
        }

        public int Get(UserProfileDataType type)
        {
            return _profileControllers[type].Get();
        }
        
        public void Add(UserProfileDataType type, int amount)
        {
            var beforeAmount = Get(type);
            _profileControllers[type].Add(amount);
            var afterAmount = Get(type);
            InvokeChanged(new UserProfileDataChangedArgs(type, beforeAmount, afterAmount));
        }

        public void Reset(UserProfileDataType type)
        {
            var beforeAmount = Get(type);
            _profileControllers[type].Reset();
            var afterAmount = Get(type);
            InvokeChanged(new UserProfileDataChangedArgs(type, beforeAmount, afterAmount));
        }
        
        public void Save()
        {
            foreach (var profileController in _profileControllers)
            {
                profileController.Value.Save();
            }
        }

        public void Load()
        {
            foreach (var profileController in _profileControllers)
            {
                profileController.Value.Load();
            }
        }

        private void InvokeChanged(UserProfileDataChangedArgs args)
        {
            Changed?.Invoke(this, args);
        }
    }
}