using Modules.ScenariosModule.Enums;
using Modules.ScenariosModule.Models;
using Modules.UIModule.Views;

namespace Modules.CommonModule.Views
{
    public abstract class BaseUiView<TViewModel> : BaseView<TViewModel> where TViewModel : IViewModel
    {
        private BaseWindowView _baseWindowView;

        public void Initialize(TViewModel viewModel)
        {
            base.Initialize(viewModel);
            _baseWindowView = GetComponent<BaseWindowView>();
        }
        
        protected void ExecuteAction(GameActionType gameActionType, GameActionArgs actionArgs = null)
        {
            _baseWindowView.ScenarioManager.ExecuteAction(gameActionType, actionArgs);
        }
    }
}