using UnityEngine;

namespace YohohoChobotov.Game.Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private BoxCollider boxCollider;

        public Transform StartPoint => startPoint;
        public BoxCollider BoxCollider => boxCollider;
    }
}