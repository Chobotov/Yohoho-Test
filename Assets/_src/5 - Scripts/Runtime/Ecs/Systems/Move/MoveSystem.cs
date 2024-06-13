using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Ecs.Input;

namespace YohohoChobotov.Ecs.Systems
{
    public class MoveSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, InputEvent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var playerEntity = ref filter.Get1(i);
                ref var input = ref filter.Get2(i);

                playerEntity.Player.Move(input.Direction);
            }
        }
    }
}