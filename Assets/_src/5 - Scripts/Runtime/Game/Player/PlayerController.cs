﻿using UnityEngine;
using YohohoChobotov.Game.Stack;

namespace YohohoChobotov.Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float speed = .1f;
        [SerializeField] private float rotationSpeed = 1f;
        [Space]
        [SerializeField] private StackController stackController;
        [SerializeField] private Animator animator;

        private Rigidbody rigidbody;
        private float velocity = 0;

        public StackController StackController => stackController;
        public Animator Animator => animator;
        public float Velocity => velocity;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
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

        public void AddDeltaVelocity(float velocity)
        {
            this.velocity += velocity;
        }
    }
}