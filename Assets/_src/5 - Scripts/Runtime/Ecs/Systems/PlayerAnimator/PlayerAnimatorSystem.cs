using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;

namespace YohohoChobotov.Ecs.Systems
{
    public class PlayerAnimatorSystem : IEcsRunSystem
    {
        private readonly int VelocityKey = Animator.StringToHash("velocity");

        private readonly EcsFilter<PlayerComponent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var entity = ref filter.Get1(i);

                var player = entity.Player;

                player.Animator.SetFloat(VelocityKey, player.Velocity);
            }
        }
    }
}