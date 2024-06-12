using UnityEngine;

namespace YohohoChobotov.Game.Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;

        public Transform StartPoint => startPoint;
    }
}