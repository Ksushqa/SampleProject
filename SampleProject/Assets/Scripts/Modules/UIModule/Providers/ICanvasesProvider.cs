using Modules.UIModule.Enums;

namespace Modules.UIModule.Providers
{
    public interface ICanvasesProvider
    {
        string GetId(CanvasType type);
    }
}