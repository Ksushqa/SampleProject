using Modules.ScenariosModule.Enums;
using Modules.UserProfileDataModule.Enums;
using Modules.UserProfileDataModule.Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.UIModule.Views.GameWindow
{
    public class GameWindowView : BaseView<GameWindowViewModel>
    {
        [SerializeField] private TextMeshProUGUI _coinsCounter = default;
        [SerializeField] private Button _backToMainMenuButton = default;
        
        protected override void OnStartActions()
        {
            _coinsCounter.text = ViewModel.UserProfileDataFacade.Get(UserProfileDataType.Coins).ToString();
        }

        protected override void OnSubscribeActions()
        {
            base.OnSubscribeActions();
            _backToMainMenuButton.onClick.AddListener(HandleBackToMainMenuButtonPressed);
            ViewModel.UserProfileDataFacade.Changed += HandleUserProfileChanged;
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
        
        private void HandleUserProfileChanged(object sender, UserProfileDataChangedArgs args)
        {
            if (args.Type == UserProfileDataType.Coins)
            {
                _coinsCounter.text = args.AfterAmount.ToString();
            }
        }
    }
}