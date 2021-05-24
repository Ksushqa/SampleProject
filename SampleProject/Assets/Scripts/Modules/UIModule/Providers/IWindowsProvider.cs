using Modules.UIModule.Enums;
using Modules.UIModule.Models;

namespace Modules.UIModule.Providers
{
    public interface IWindowsProvider
    {
        WindowDataModel GetWindowModel(WindowType type);
    }
}