using Modules.UIModule.Enums;
using Modules.UIModule.Views;

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