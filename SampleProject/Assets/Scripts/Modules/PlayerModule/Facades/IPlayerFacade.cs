using Modules.PlayerModule.Views;

namespace Modules.PlayerModule.Facades
{
    public interface IPlayerFacade
    {
        PlayerView Player { get; }
        void Create();
        void Destroy();
    }
}