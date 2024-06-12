using Cinemachine;
using UnityEngine;
using YohohoChobotov.Game.Levels;
using YohohoChobotov.Game.Player;

namespace YohohoChobotov.Game
{
    public class GameLogic : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera camera;
        [Header("Factories")]
        [SerializeField] private LevelFactory levelFactory;
        [SerializeField] private PlayerFactory playerFactory;

        public LevelFactory LevelFactory => levelFactory;
        public PlayerFactory PlayerFactory => playerFactory;

        private void Start()
        {
            CreateLevel();
            CreatePlayer();

            SetCameraFollow(playerFactory.Player.transform);
        }

        private void CreatePlayer()
        {
            playerFactory.CreatePlayer(levelFactory.LevelField.StartPoint.position);
        }

        private void CreateLevel()
        {
            levelFactory.CreateLevelField();
        }

        private void SetCameraFollow(Transform follow)
        {
            camera.Follow = follow;
        }
    }
}