using Modules.CommonModule.Enums;
using Modules.CommonModule.Views;
using UnityEngine;

namespace Modules.GameElementsModule.Views
{
    public class CoinView : BaseGameView<CoinViewModel>
    {
        protected override void OnStartActions()
        {
            
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagTypes.Player.ToString()))
            {
                ViewModel.GameElementFacade.DestroyCoin(this);
            }
        }
    }
}