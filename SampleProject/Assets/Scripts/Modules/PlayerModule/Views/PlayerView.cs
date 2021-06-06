using Modules.CommonModule.Controllers;
using Modules.CommonModule.Enums;
using Modules.UIModule.Views;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Modules.PlayerModule.Views
{
    public class PlayerView : BaseView<PlayerViewModel>
    {
        private bool _isMoving;
        private Vector3 _nextPosition;

        protected override void OnStartActions()
        {
        }

        private void Update()
        {
            if (!_isMoving)
            {
                return;
            }
            
            var currentPosition = transform.position;
            transform.position = Vector3.MoveTowards(currentPosition, _nextPosition, Time.deltaTime * ViewModel.Speed);
                
            var distance = Vector3.Distance(_nextPosition, currentPosition);
            if (distance > 0f)
            {
                var direction = (_nextPosition - transform.position).normalized;
                transform.up = direction;
            }

            if (distance < 0.05f)
            {
                _isMoving = false;
            }
        }

        protected override void OnSubscribeActions()
        {
            base.OnSubscribeActions();

            ViewModel.MouseUserActionController.UserActionHappened += HandleUserActionHappened;
        }

        protected override void OnUnsubscribeActions()
        {
            base.OnUnsubscribeActions();

            ViewModel.MouseUserActionController.UserActionHappened -= HandleUserActionHappened;
        }

        private void HandleUserActionHappened(object sender, UserActionArgs args)
        {
            if (args.Type == UserActionType.PointerDown)
            {
                _isMoving = true;
                SetUpNextPosition();
            }
        }

        private void SetUpNextPosition()
        {
            var screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -ViewModel.MainCamera.transform.position.z);
            screenPosition.x = Mathf.Clamp(screenPosition.x, 0f, Screen.width);
            screenPosition.y = Mathf.Clamp(screenPosition.y, 0f, Screen.height);
            _nextPosition = ViewModel.MainCamera.ScreenToWorldPoint(screenPosition);
            _nextPosition.z = transform.position.z;
        }
    }
}