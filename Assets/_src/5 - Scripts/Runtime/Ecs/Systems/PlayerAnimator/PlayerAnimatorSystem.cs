using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Game.Player;

namespace YohohoChobotov.Ecs.Systems
{
    public class PlayerAnimatorSystem : IEcsRunSystem
    {
        private readonly int VelocityKey = Animator.StringToHash("velocity");

        private PlayerFactory factory;

        public void Run()
        {
            if (!factory.Player) return;

            var player = factory.Player;

            player.Animator.SetFloat(VelocityKey, player.Velocity);
        }
    }
}