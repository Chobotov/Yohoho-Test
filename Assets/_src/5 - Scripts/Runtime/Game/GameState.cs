using Cinemachine;
using UnityEngine;
using VContainer;
using YohohoChobotov.Game.Items;
using YohohoChobotov.Game.Levels;
using YohohoChobotov.Game.Player;

namespace YohohoChobotov.Game
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera camera;

        [Inject] private IFactory<LevelView> levelFactory;
        [Inject] private IFactory<UnitView> playerFactory;
        [Inject] private IFactory<Item> itemsFactory;

        public CinemachineVirtualCamera Camera => camera;

        public IFactory<Item> ItemsFactory => itemsFactory;
        public IFactory<LevelView> LevelFactory => levelFactory;
        public IFactory<UnitView> PlayerFactory => playerFactory;
    }
}