using System;
using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Models;
using UnityEngine;

namespace Modules.UIModule.Views
{
    public abstract class BaseView : BaseView<IViewModel>
    {
        
    }
    
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
        private BaseWindowView _baseWindowView;

        public void Initialize(TViewModel viewModel)
        {
            _baseWindowView = GetComponent<BaseWindowView>();
            _viewModel = viewModel;
        }

        protected void ExecuteAction(GameActionType gameActionType, GameActionArgs actionArgs = null)
        {
            _baseWindowView.ScenarioManager.ExecuteAction(gameActionType, actionArgs);
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