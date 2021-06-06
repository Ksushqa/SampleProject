using Modules.PlayerModule.Views;
using UnityEngine;

namespace Modules.PlayerModule.Providers
{
    [CreateAssetMenu(menuName = "SampleProject/Create PlayerDataConfig", fileName = "PlayerDataConfig")]
    public class PlayerDataProvider : ScriptableObject
    {
        [SerializeField] private PlayerView _playerPrefab = default;
        [SerializeField] private float _speed = default;

        public PlayerView PlayerPrefab => _playerPrefab;
        public float Speed => _speed;
    }
}