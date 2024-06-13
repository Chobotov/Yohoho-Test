using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Game;

namespace YohohoChobotov.Ecs.Systems
{
    public class CameraInitSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent> filter;

        private GameState state;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var player = ref filter.Get1(i);
                state.Camera.Follow = player.Player.transform;
            }
        }
    }
}