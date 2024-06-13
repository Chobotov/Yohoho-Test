using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Ecs.Input;

namespace YohohoChobotov.Ecs.Systems
{
    public class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent> filter;

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