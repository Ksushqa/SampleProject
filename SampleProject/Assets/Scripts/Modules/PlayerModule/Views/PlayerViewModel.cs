using Modules.CommonModule.Controllers;
using Modules.UIModule.Views;
using UnityEngine;

namespace Modules.PlayerModule.Views
{
    public class PlayerViewModel : IViewModel
    {
        public Camera MainCamera { get; }
        public MouseUserActionController MouseUserActionController { get; }
        public float Speed { get; }

        public PlayerViewModel(Camera mainCamera, MouseUserActionController mouseUserActionController, float speed)
        {
            MainCamera = mainCamera;
            MouseUserActionController = mouseUserActionController;
            Speed = speed;
        }
    }
}