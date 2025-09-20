using UnityEngine;

namespace YohohoChobotov.Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class Rotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 1f;

        private Rigidbody rigidbody;

        public void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Rotate(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                var targetRotation = Quaternion.LookRotation(new Vector3(direction.x, transform.position.y, direction.y));
                rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
            }
        }
    }
}