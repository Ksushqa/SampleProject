using Modules.CommonModule.Views;
using Modules.GameElementsModule.Facades;
using Modules.UserProfileDataModule.Enums;

namespace Modules.GameElementsModule.Views
{
    public class CoinViewModel : IViewModel
    {
        public UserProfileDataType UserProfileDataType { get; }
        public IGameElementFacade GameElementFacade { get; }

        public CoinViewModel(
            UserProfileDataType userProfileDataType,
            IGameElementFacade gameElementFacade)
        {
            UserProfileDataType = userProfileDataType;
            GameElementFacade = gameElementFacade;
        }
    }
}