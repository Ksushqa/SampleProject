using UnityEngine;

namespace Modules.UIModule.Views
{
    [RequireComponent(typeof(Animator))]
    public class BaseWindowView : MonoBehaviour
    {
        public float TimeBeforeDestroy = 0.5f;
        
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void PlayDestroy()
        {
            _animator.CrossFade("window_destroy", 0.05f);
        }
    }
}