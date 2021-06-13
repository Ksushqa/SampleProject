using Modules.CommonModule.Views;
using Modules.UserProfileDataModule.Facades;

namespace Modules.UIModule.Views.GameWindow
{
    public class UserProfileViewModel : IViewModel
    {
        public IUserProfileDataFacade UserProfileDataFacade { get; }

        public UserProfileViewModel(IUserProfileDataFacade userProfileDataFacade)
        {
            UserProfileDataFacade = userProfileDataFacade;
        }
    }
}