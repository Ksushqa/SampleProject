using System;
using UnityEngine;

namespace Modules.UIModule.Views
{
    public abstract class BaseView<TViewModel> : MonoBehaviour
        where TViewModel : IViewModel
    {
        [NonSerialized] protected GameObject GameObject;
        
        protected abstract void OnStartActions();

        protected TViewModel ViewModel
        {
            get
            {
                if (_viewModel == null)
                {
                    throw new NullReferenceException($"You trying to use ViewModel of BaseView<{typeof(TViewModel)}> but it equals null. " +
                                                     $"This View is not initialized");
                }

                return _viewModel;
            }
        }

        private TViewModel _viewModel;
        private bool _isSubscribed;

        public void Initialize(TViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        
        protected virtual void OnDestroyActions()
        {
        }

        protected virtual void OnSubscribeActions()
        {
        }

        protected virtual void OnUnsubscribeActions()
        {
        }
        
        private void Start()
        {
            GameObject = gameObject;
            OnStartActions();
        }

        private void OnDestroy()
        {
            OnDestroyActions();
        }

        private void OnEnable()
        {
            if (!_isSubscribed)
            {
                OnSubscribeActions();
            }
        }

        private void OnDisable()
        {
            if (_isSubscribed)
            {
                OnUnsubscribeActions();
            }
        }
    }
}