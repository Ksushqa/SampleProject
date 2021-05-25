namespace Modules.UIModule.Views
{
    public interface IBaseView<TViewModel>
    {
        void Initialize(TViewModel viewModel);
    }
}