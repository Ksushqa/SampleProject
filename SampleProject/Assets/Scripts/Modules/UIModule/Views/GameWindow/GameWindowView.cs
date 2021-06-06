using System.Collections.Generic;
using Modules.ScenariosModule.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.UIModule.Views.GameWindow
{
    public class GameWindowView : BaseView<GameWindowViewModel>
    {
        [SerializeField] private List<UserProfileView> _userProfileViews = default;
        [SerializeField] private Button _backToMainMenuButton = default;
        
        protected override void OnStartActions()
        {
            foreach (var userProfileView in _userProfileViews)
            {
                AddSubView(userProfileView, new UserProfileViewModel(ViewModel.UserProfileDataFacade));
            }
        }

        protected override void OnSubscribeActions()
        {
            base.OnSubscribeActions();
            _backToMainMenuButton.onClick.AddListener(HandleBackToMainMenuButtonPressed);
        }

        protected override void OnUnsubscribeActions()
        {
            base.OnUnsubscribeActions();
            _backToMainMenuButton.onClick.RemoveListener(HandleBackToMainMenuButtonPressed);
        }
        
        private void HandleBackToMainMenuButtonPressed()
        {
            ExecuteAction(GameActionType.BackToMainMenuPressed);
        }
    }
}