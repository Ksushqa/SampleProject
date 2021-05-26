namespace Modules.UIModule.Views
{
    public interface IBaseView<TViewModel> where TViewModel : IViewModel
    {
        void Initialize(TViewModel viewModel);
    }
}