using Modules.PlayerModule.Views;
using UnityEngine;

namespace Modules.PlayerModule.Providers
{
    [CreateAssetMenu(menuName = "SampleProject/Create PlayerDataConfig", fileName = "PlayerDataConfig")]
    public class PlayerDataProvider : ScriptableObject
    {
        [SerializeField] private PlayerView _playerPrefab = default;

        public PlayerView PlayerPrefab => _playerPrefab;
    }
}