using System;

namespace Modules.CommonModule.Controllers
{
    public interface IUserActionController
    {
        event EventHandler<UserActionArgs> UserActionHappened;
    }
}