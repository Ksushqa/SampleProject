using Modules.UIModule.Views;

namespace Modules.CommonModule.Views
{
    public interface IBaseView<TViewModel> where TViewModel : IViewModel
    {
        void Initialize(TViewModel viewModel);
    }
}