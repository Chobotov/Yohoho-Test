using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;

namespace YohohoChobotov.Ecs.Systems
{
    public class AnimatorSystem : IEcsRunSystem
    {
        private readonly int VelocityKey = Animator.StringToHash("velocity");

        private readonly EcsFilter<UnitComponent, MoveComponent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var unitComponent = ref filter.Get1(i);
                ref var moveComponent = ref filter.Get2(i);

                var velocity = moveComponent.Moveble.Velocity;
                unitComponent.Unit.Animator.SetFloat(VelocityKey, velocity);
            }
        }
    }
}