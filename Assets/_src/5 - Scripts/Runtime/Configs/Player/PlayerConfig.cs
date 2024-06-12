using YohohoChobotov.Game.Player;
using UnityEngine;

namespace YohohoChobotov.Configs.Player
{
    [CreateAssetMenu(fileName = "Player Config", menuName = "Game/Configs/Player Config", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private PlayerController playerPrefab;

        public PlayerController PlayerPrefab => playerPrefab;
    }
}