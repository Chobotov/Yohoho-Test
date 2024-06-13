using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Ecs.Input;

namespace YohohoChobotov.Ecs.Systems
{
    public class PlayerVelocitySystem : IEcsRunSystem
    {
        private const float Acceleration = 5f;
        private const float Deceleration = 10f;

        private readonly EcsFilter<PlayerComponent, InputEvent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var playerEntity = ref filter.Get1(i);
                ref var input = ref filter.Get2(i);

                var player = playerEntity.Player;

                if (!Vector3.zero.Equals(input.Direction) && player.Velocity < 1f)
                {
                    player.AddDeltaVelocity(Time.deltaTime * Acceleration);
                }

                if (Vector3.zero.Equals(input.Direction) && player.Velocity > 0f)
                {
                    player.AddDeltaVelocity(-Time.deltaTime * Deceleration);
                }
            }
        }
    }
}