using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Game;

namespace YohohoChobotov.Ecs.Systems
{
    public class CreatePlayerSystem : IEcsInitSystem
    {
        private EcsWorld world;
        private GameState state;

        public void Init()
        {
            var spawnPosition = state.LevelFactory.LevelField.StartPoint.position;
            var player = state.PlayerFactory.CreatePlayer(spawnPosition);

            var newEntity = world.NewEntity();

            newEntity.Get<PlayerComponent>().Player = player;
            newEntity.Get<MoveComponent>().Transform = player.transform;

            ref var stack = ref newEntity.Get<StackComponent>();
            stack.Stack = player.StackController;
            stack.Items = new();
        }
    }
}