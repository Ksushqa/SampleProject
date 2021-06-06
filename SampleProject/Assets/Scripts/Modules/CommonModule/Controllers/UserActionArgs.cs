using System;
using Modules.CommonModule.Enums;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Modules.CommonModule.Controllers
{
    public class UserActionArgs : EventArgs
    {
        public UserActionType Type { get; }
        public KeyCode KeyCode { get; }
        public PointerEventData PointerEventData { get; }

        public UserActionArgs(UserActionType type)
        {
            Type = type;
        }
    
        public UserActionArgs(UserActionType type, PointerEventData pointerEventData)
        {
            Type = type;
            PointerEventData = pointerEventData;
        }
    
        public UserActionArgs(UserActionType type, KeyCode keyCode)
        {
            Type = type;
            KeyCode = keyCode;
        }
    }
}
