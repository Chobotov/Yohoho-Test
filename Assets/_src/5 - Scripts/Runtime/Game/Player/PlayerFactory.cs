using UnityEngine;
using VContainer;
using VContainer.Unity;
using YohohoChobotov.Configs.Player;

namespace YohohoChobotov.Game.Player
{
    public class PlayerFactory : MonoBehaviour
    {
        private IObjectResolver resolver;

        private PlayerConfig config;
        private PlayerController player;

        public PlayerController Player => player;

        [Inject]
        public void Inject(IObjectResolver resolver, PlayerConfig config)
        {
            this.resolver = resolver;
            this.config = config;
        }

        public void CreatePlayer(Vector3 spawnPos)
        {
            player = resolver.Instantiate(
                config.PlayerPrefab,
                spawnPos,
                Quaternion.identity,
                transform);
        }
    }
}