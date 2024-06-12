using Leopotam.Ecs;
using YohohoChobotov.Ecs.Input;
using YohohoChobotov.Game.Player;

namespace YohohoChobotov.Ecs.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputEvent> filter;

        private PlayerFactory factory;

        public void Run()
        {
            if (!factory.Player) return;

            foreach (var i in filter)
            {
                ref var input = ref filter.Get1(i);

                factory.Player.Move(input.Direction);
            }
        }
    }
}