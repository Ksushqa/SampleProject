using Modules.CommonModule.Views;
using Modules.UIModule.Enums;

namespace Modules.UIModule.Controllers
{
    public interface IUIController
    {
        void ShowWindow<TViewModel>(WindowType windowType, TViewModel viewModel)
            where TViewModel : IViewModel;

        bool HideWindow(WindowType windowType);

        void HideAllWindows();
    }
}