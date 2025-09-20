using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Game;

namespace YohohoChobotov.Ecs.Systems
{
    public class CreateUnitSystem : IEcsInitSystem
    {
        private EcsWorld world;
        private GameState state;

        private readonly EcsFilter<LevelComponent> filter;

        public void Init()
        {
            var spawnPosition = filter.Get1(0).Level.StartPoint.position;
            var player = state.PlayerFactory.Create(spawnPosition);

            var newEntity = world.NewEntity();

            newEntity.Get<UnitComponent>().Unit = player;
            newEntity.Get<MoveComponent>().Moveble = player.Moveble;
            newEntity.Get<RotationComponent>().Rotation = player.Rotation;

            ref var stack = ref newEntity.Get<InventoryComponent>();
            stack.Stack = player.UnitInventory;
            stack.Items = new();
        }
    }
}