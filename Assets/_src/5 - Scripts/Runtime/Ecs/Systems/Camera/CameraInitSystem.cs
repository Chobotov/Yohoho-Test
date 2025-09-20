using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Game;

namespace YohohoChobotov.Ecs.Systems
{
    public class CameraInitSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnitComponent> filter;

        private GameState state;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var component = ref filter.Get1(i);
                state.Camera.Follow = component.Unit.transform;
            }
        }
    }
}