using System;
using Modules.CommonModule.Enums;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.CommonModule.Controllers
{
    public class CanvasUserActionController : MonoBehaviour, IUserActionController, IPointerDownHandler, IPointerUpHandler, IDragHandler
    {
        public event EventHandler<UserActionArgs> UserActionHappened;

        public void OnPointerDown(PointerEventData eventData)
        {
            UserActionHappened?.Invoke(this, new UserActionArgs(UserActionType.PointerDown, eventData));
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            UserActionHappened?.Invoke(this, new UserActionArgs(UserActionType.PointerUp, eventData));
        }

        public void OnDrag(PointerEventData eventData)
        {
            UserActionHappened?.Invoke(this, new UserActionArgs(UserActionType.PointerDrag, eventData));
        }
    }
}