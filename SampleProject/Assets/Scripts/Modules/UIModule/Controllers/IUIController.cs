using Modules.UIModule.Enums;
using Modules.UIModule.Views;

namespace Modules.UIModule.Controllers
{
    public interface IUIController
    {
        TView ShowWindow<TView, TViewModel>(WindowType windowType, TViewModel viewModel)
            where TView : IBaseView<TViewModel>
            where TViewModel : IViewModel;

        void ShowWindow<TViewModel>(WindowType windowType, TViewModel viewModel)
            where TViewModel : IViewModel;

        bool HideWindow(WindowType windowType);
    }
}