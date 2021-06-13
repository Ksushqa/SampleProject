using Modules.GameElementsModule.Views;

namespace Modules.GameElementsModule.Facades
{
    public interface IGameElementFacade
    {
        void Start();
        void Stop();

        void DestroyCoin(CoinView coinView);
    }
}