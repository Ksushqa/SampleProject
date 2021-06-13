using Modules.CommonModule.Views;
using Modules.UserProfileDataModule.Facades;

namespace Modules.UIModule.Views.GameWindow
{
    public class GameWindowViewModel : IViewModel
    {
        public IUserProfileDataFacade UserProfileDataFacade { get; }

        public GameWindowViewModel(IUserProfileDataFacade userProfileDataFacade)
        {
            UserProfileDataFacade = userProfileDataFacade;
        }
    }
}