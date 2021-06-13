using Modules.CommonModule.Views;
using Modules.UserProfileDataModule.Enums;
using Modules.UserProfileDataModule.Models;
using TMPro;
using UnityEngine;

namespace Modules.UIModule.Views.GameWindow
{
    public class UserProfileView : BaseUiView<UserProfileViewModel>
    {
        [SerializeField] private UserProfileDataType _profileType;
        [SerializeField] private TextMeshProUGUI _profileName;
        [SerializeField] private TextMeshProUGUI _counter;
        
        protected override void OnStartActions()
        {
            _counter.text = ViewModel.UserProfileDataFacade.Get(_profileType).ToString();
            _profileName.text = _profileType.ToString();
        }

        protected override void OnSubscribeActions()
        {
            base.OnSubscribeActions();
            ViewModel.UserProfileDataFacade.Changed += HandleUserProfileChanged;
        }

        protected override void OnDestroyActions()
        {
            base.OnDestroyActions();
            ViewModel.UserProfileDataFacade.Changed -= HandleUserProfileChanged;
        }
                
        private void HandleUserProfileChanged(object sender, UserProfileDataChangedArgs args)
        {
            if (args.Type == UserProfileDataType.Coins)
            {
                _counter.text = args.AfterAmount.ToString();
            }
        }
    }
}