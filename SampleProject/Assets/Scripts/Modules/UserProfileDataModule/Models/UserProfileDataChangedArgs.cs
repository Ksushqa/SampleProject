using Modules.UserProfileDataModule.Enums;

namespace Modules.UserProfileDataModule.Models
{
    public class UserProfileDataChangedArgs
    {
        public UserProfileDataType Type { get; }
        public int BeforeAmount { get; }
        public int AfterAmount { get; }

        public UserProfileDataChangedArgs(UserProfileDataType type, int beforeAmount, int afterAmount)
        {
            Type = type;
            BeforeAmount = beforeAmount;
            AfterAmount = afterAmount;
        }
    }
}