using Modules.CommonModule.Views;
using Modules.UIModule.Enums;

namespace Modules.UIModule.Managers
{
    public interface IUIManager
    {
        void Show<TViewModel>(WindowType windowType, TViewModel viewModel) where TViewModel : IViewModel;
        void Hide(WindowType windowType);
        void HideAll();
    }
}