using Leopotam.Ecs;
using YohohoChobotov.Ecs.Player;
using YohohoChobotov.Game.Player;

namespace YohohoChobotov.Ecs.Systems
{
    public class CreatePlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CreatePlayer> filter;

        private PlayerFactory factory;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);
                ref var info = ref filter.Get1(i);

                factory.CreatePlayer(info.SpawnPosition);

                entity.Destroy();
            }
        }
    }
}