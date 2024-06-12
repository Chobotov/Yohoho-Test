using UnityEngine;
using VContainer;
using YohohoChobotov.Configs.Player;

namespace YohohoChobotov.Game.Player
{
    public class PlayerFactory : MonoBehaviour
    {
        private PlayerConfig config;

        private PlayerController player;

        public PlayerController Player => player;

        [Inject]
        public void Inject(PlayerConfig config)
        {
            this.config = config;
        }

        public void CreatePlayer(Vector3 spawnPos)
        {
            player = Instantiate(
                config.PlayerPrefab, 
                spawnPos, 
                Quaternion.identity, 
                transform);
        }
    }
}