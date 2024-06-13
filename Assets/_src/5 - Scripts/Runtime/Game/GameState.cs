using Cinemachine;
using UnityEngine;
using YohohoChobotov.Game.Items;
using YohohoChobotov.Game.Levels;
using YohohoChobotov.Game.Player;

namespace YohohoChobotov.Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera camera;
        [Header("Factories")]
        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private PlayerFactory playerFactory;
        [SerializeField] private ItemsFactory itemsFactory;

        public CinemachineVirtualCamera Camera => camera;
        public ItemsFactory ItemsFactory => itemsFactory;
        public LevelFactory LevelFactory => levelFactory;
        public PlayerFactory PlayerFactory => playerFactory;
    }
}