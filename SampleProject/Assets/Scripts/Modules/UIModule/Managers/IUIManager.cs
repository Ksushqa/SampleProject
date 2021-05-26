using Modules.UIModule.Enums;
using Modules.UIModule.Views;

namespace Modules.UIModule.Managers
{
    public interface IUIManager
    {
        void Show<TView, TViewModel>(WindowType windowType, TViewModel viewModel)
            where TView : IBaseView<TViewModel>
            where TViewModel : IViewModel;

        void Show<TViewModel>(WindowType windowType, TViewModel viewModel) where TViewModel : IViewModel;
        void Hide(WindowType windowType);
        void HideAll();
    }
}