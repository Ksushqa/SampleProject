using Modules.UIModule.Enums;
using Modules.UIModule.Views;

namespace Modules.UIModule.Managers
{
    public interface IUIManager
    {
        TView ShowWindow<TView, TViewModel>(WindowType windowType, TViewModel viewModel)
            where TView : IBaseView<TViewModel>
            where TViewModel : IViewModel;
    }
}