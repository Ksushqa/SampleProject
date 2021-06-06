using System;
using Modules.CommonModule.Enums;
using UnityEngine;

namespace Modules.CommonModule.Controllers
{
    public class KeyboardUserActionController : MonoBehaviour, IUserActionController
    {
        public event EventHandler<UserActionArgs> UserActionHappened;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                RaiseUserActionHappened(UserActionType.KeyDown, KeyCode.LeftArrow);
                return;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RaiseUserActionHappened(UserActionType.KeyDown, KeyCode.RightArrow);
                return;
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                RaiseUserActionHappened(UserActionType.KeyUp, KeyCode.LeftArrow);
                return;
            }
            
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                RaiseUserActionHappened(UserActionType.KeyUp, KeyCode.RightArrow);
                return;
            }
        }

        private void RaiseUserActionHappened(UserActionType userActionType, KeyCode keyCode)
        {
            UserActionHappened?.Invoke(this, new UserActionArgs(userActionType, keyCode));            
        }
    }
}