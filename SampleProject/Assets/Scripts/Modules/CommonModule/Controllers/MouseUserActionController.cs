using System;
using Modules.CommonModule.Enums;
using UnityEngine;

namespace Modules.CommonModule.Controllers
{
    public class MouseUserActionController : MonoBehaviour, IUserActionController
    {
        public event EventHandler<UserActionArgs> UserActionHappened;

        private bool _isDragging;
    
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnPointerDown();
                _isDragging = true;
                return;
            }

            if (Input.GetMouseButtonUp(0))
            {
                OnPointerUp();
                _isDragging = false;
                return;
            }

            if (_isDragging)
            {
                OnDrag();
                return;
            }
        }
    
        private void OnDrag()
        {
            UserActionHappened?.Invoke(this, new UserActionArgs(UserActionType.PointerDrag, null));
        }

        private void OnPointerDown()
        {
            UserActionHappened?.Invoke(this, new UserActionArgs(UserActionType.PointerDown, null));
        }

        private void OnPointerUp()
        {
            UserActionHappened?.Invoke(this, new UserActionArgs(UserActionType.PointerUp, null));
        }
    }
}