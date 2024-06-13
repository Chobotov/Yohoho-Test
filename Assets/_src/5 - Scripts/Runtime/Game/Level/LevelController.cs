using UnityEngine;

namespace YohohoChobotov.Game.Levels
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private Transform startPoint;
        [SerializeField] private BoxCollider boxCollider;
        [SerializeField] private BoxCollider dropZone;

        public Transform StartPoint => startPoint;
        public BoxCollider DropZone => dropZone;
        public BoxCollider BoxCollider => boxCollider;
    }
}