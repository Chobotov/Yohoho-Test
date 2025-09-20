using UnityEngine;

namespace YohohoChobotov.Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Moveble : MonoBehaviour
    {
        [SerializeField] private float speed = .1f;

        private Rigidbody rigidbody;

        private float velocity;

        public float Velocity => velocity;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector2 direction)
        {
            rigidbody.MovePosition(rigidbody.position + new Vector3(direction.x, transform.position.y, direction.y) * speed);
        }

        public void AddDeltaVelocity(float velocity)
        {
            this.velocity += velocity;
        }
    }
}