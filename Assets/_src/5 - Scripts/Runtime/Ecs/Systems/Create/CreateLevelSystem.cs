using Leopotam.Ecs;
using YohohoChobotov.Ecs.Level;
using YohohoChobotov.Game.Levels;

namespace YohohoChobotov.Ecs.Systems
{
    public class CreateLevelSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CreateLevel> filter;
        private LevelFactory factory;

        public void Run()
        {
            foreach (var i in filter)
            {
                /*ref var entity = ref filter.GetEntity(i);
                ref var level = ref filter.Get1(i);

                factory.CreateLevelField(level.Level);

                entity.Destroy();*/
            }
        }
    }
}