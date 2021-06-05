using Modules.UIModule.Enums;
using Modules.UIModule.Models;

namespace Modules.UIModule.Providers
{
    public interface IWindowViewProvider
    {
        CanvasWindowModel GetOrAddWindow(WindowType windowType);
        bool RemoveWindow(WindowType windowType);
        void RemoveAllWindows();
    }
}