using System;
using UnityEngine;

namespace Modules.CommonModule.Views
{
    public abstract class BaseView<TViewModel> : MonoBehaviour, IBaseView<TViewModel>
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

        public virtual void Initialize(TViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        protected void AddSubView<T>(BaseView<T> subView, T viewModel) where T : IViewModel
        {
            subView.Initialize(viewModel);
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
            
            if (!_isSubscribed)
            {
                OnSubscribeActions();
                _isSubscribed = true;
            }
        }

        private void OnDestroy()
        {
            OnDestroyActions();
            
            if (_isSubscribed)
            {
                OnUnsubscribeActions();
                _isSubscribed = false;
            }
        }
    }
}