using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Input;
using YohohoChobotov.Game.Player;

namespace YohohoChobotov.Ecs.Systems
{
    public class PlayerVelocitySystem : IEcsRunSystem
    {
        private const float acceleration = 5f;
        private const float deceleration = 10f;

        private readonly EcsFilter<InputEvent> filter;

        private PlayerFactory factory;

        public void Run()
        {
            if (!factory.Player) return;

            foreach (var i in filter)
            {
                ref var input = ref filter.Get1(i);

                var player = factory.Player;

                if (!Vector3.zero.Equals(input.Direction) && player.Velocity < 1f)
                {
                    player.AddDeltaVelocity(Time.deltaTime * acceleration);
                }

                if (Vector3.zero.Equals(input.Direction) && player.Velocity > 0f)
                {
                    player.AddDeltaVelocity(-Time.deltaTime * deceleration);
                }
            }
        }
    }
}