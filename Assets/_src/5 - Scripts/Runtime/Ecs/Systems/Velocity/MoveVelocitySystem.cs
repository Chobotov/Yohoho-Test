using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Ecs.Input;

namespace YohohoChobotov.Ecs.Systems
{
    public class MoveVelocitySystem : IEcsRunSystem
    {
        private const float Acceleration = 5f;
        private const float Deceleration = 10f;

        private readonly EcsFilter<MoveComponent, InputEvent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var component = ref filter.Get1(i);
                ref var input = ref filter.Get2(i);

                var moveController = component.Moveble;

                if (!Vector3.zero.Equals(input.Direction) && moveController.Velocity < 1f)
                {
                    moveController.AddDeltaVelocity(Time.deltaTime * Acceleration);
                }

                if (Vector3.zero.Equals(input.Direction) && moveController.Velocity > 0f)
                {
                    moveController.AddDeltaVelocity(-Time.deltaTime * Deceleration);
                }
            }
        }
    }
}