using Modules.ScenariosModule.Managers;
using UnityEngine;

namespace Modules.UIModule.Views
{
    [RequireComponent(typeof(Animator))]
    public class BaseWindowView : MonoBehaviour
    {
        public float TimeBeforeDestroy { get; } = 0.5f;
        public IScenarioManager ScenarioManager { get; private set; }
        
        private Animator _animator;

        public void Init(IScenarioManager scenarioManager)
        {
            ScenarioManager = scenarioManager;
        }
        
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