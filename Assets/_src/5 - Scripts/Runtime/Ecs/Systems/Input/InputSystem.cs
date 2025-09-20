using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Ecs.Input;

namespace YohohoChobotov.Ecs.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnitComponent> filter;

        private FixedJoystick joystick;

        private EcsWorld world;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);

                var dir = joystick.Direction;
                entity.Get<InputEvent>().Direction = dir;
            }
        }
    }
}