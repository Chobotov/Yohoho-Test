using Leopotam.Ecs;
using YohohoChobotov.Ecs.Input;

namespace YohohoChobotov.Ecs.Systems
{
    public class InputSystem : IEcsRunSystem
    {
        private FixedJoystick joystick;

        private EcsWorld world;

        public void Run()
        {
            var dir = joystick.Direction;

            world.NewEntity().Get<InputEvent>().Direction = dir;
        }
    }
}