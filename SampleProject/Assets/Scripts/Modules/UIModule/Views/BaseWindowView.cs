using System.Collections;
using UnityEngine;

namespace Modules.UIModule.Views
{
    [RequireComponent(typeof(Animator))]
    public class BaseWindowView : MonoBehaviour
    {
        private const float TimeBeforeDestroy = 0.5f;
        
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            _animator.CrossFade("window_start", 0.1f);
        }

        private IEnumerable OnDestroy()
        {
            _animator.CrossFade("window_destroy", 0.1f);
            yield return new WaitForSeconds(TimeBeforeDestroy);
        }
    }
}