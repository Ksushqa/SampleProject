using Modules.UserProfileDataModule.Enums;
using UnityEngine;

namespace Modules.UserProfileDataModule.Controllers
{
    public class UserProfileDataController : IUserProfileDataController
    {
        private int _currentAmount;

        private readonly UserProfileDataType _userProfileDataType;
        
        public UserProfileDataController(UserProfileDataType userProfileDataType)
        {
            _userProfileDataType = userProfileDataType;
        }

        public int Get()
        {
            return _currentAmount;
        }
        
        public void Add(int amount)
        {
            _currentAmount += amount;
        }

        public void Reset()
        {
            _currentAmount = 0;
        }

        public void Save()
        {
            PlayerPrefs.SetInt($"profile_{_userProfileDataType.ToString()}", _currentAmount);
        }

        public void Load()
        {
            _currentAmount = PlayerPrefs.GetInt($"profile_{_userProfileDataType.ToString()}", 0);
        }
    }
}