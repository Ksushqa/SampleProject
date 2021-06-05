using Modules.ScenariosModule.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.UIModule.Views.MainWindow
{
    public class MainWindowView : BaseView<MainWindowViewModel>
    {
        [SerializeField] private Button _startGameButton = default;
        
        protected override void OnStartActions()
        {
            
        }

        protected override void OnSubscribeActions()
        {
            base.OnSubscribeActions();
            
            _startGameButton.onClick.AddListener(StartGameButtonPressed);
        }

        protected override void OnUnsubscribeActions()
        {
            base.OnUnsubscribeActions();
            
            _startGameButton.onClick.RemoveListener(StartGameButtonPressed);
        }

        private void StartGameButtonPressed()
        {
            ExecuteAction(GameActionType.StartGameButtonPressed);
        }
    }
}