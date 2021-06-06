using Modules.GameElementsModule.Views;
using UnityEngine;

namespace Modules.GameElementsModule.Providers
{
    [CreateAssetMenu(menuName = "SampleProject/Create GameElementsDataConfig", fileName = "GameElementsDataConfig")]
    public class GameElementsDataProvider : ScriptableObject
    {
        [SerializeField] private CoinView _coinPrefab;

        public CoinView CoinPrefab => _coinPrefab;
    }
}