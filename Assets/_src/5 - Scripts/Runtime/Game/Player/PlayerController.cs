using System;
using UnityEngine;

namespace YohohoChobotov.Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = .1f;
        [SerializeField] private float rotationSpeed = 1f;

        private Rigidbody rigidbody;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        public void Init()
        {
            
        }

        public void Move(Vector2 direction)
        {
            rigidbody.MovePosition(rigidbody.position + new Vector3(direction.x, transform.position.y, direction.y) * speed);
        }

        public void Rotation(Vector2 direction)
        {
            if (direction != Vector2.zero)
            {
                var targetRotation = Quaternion.LookRotation(new Vector3(direction.x, transform.position.y, direction.y));
                rigidbody.rotation = Quaternion.Slerp(rigidbody.rotation, targetRotation, Time.fixedDeltaTime * rotationSpeed);
            }
        }
    }
}