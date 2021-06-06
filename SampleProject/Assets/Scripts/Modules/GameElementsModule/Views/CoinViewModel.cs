using Modules.UIModule.Views;
using Modules.UserProfileDataModule.Enums;
using Modules.UserProfileDataModule.Facades;

namespace Modules.GameElementsModule.Views
{
    public class CoinViewModel : IViewModel
    {
        public IUserProfileDataFacade UserProfileDataFacade { get; }
        public UserProfileDataType UserProfileDataType { get; }

        public CoinViewModel(IUserProfileDataFacade userProfileDataFacade, UserProfileDataType userProfileDataType)
        {
            UserProfileDataFacade = userProfileDataFacade;
            UserProfileDataType = userProfileDataType;
        }
    }
}