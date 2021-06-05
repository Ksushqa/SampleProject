using System;
using Modules.SaveModule.Interfaces;
using Modules.UserProfileDataModule.Enums;
using Modules.UserProfileDataModule.Models;

namespace Modules.UserProfileDataModule.Facades
{
    public interface IUserProfileDataFacade : ISavable
    {
        event EventHandler<UserProfileDataChangedArgs> Changed;
        int Get(UserProfileDataType type);
        void Add(UserProfileDataType type, int amount);
        void Reset(UserProfileDataType type);
    }
}