using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Services;

namespace YohohoChobotov.Ecs.Systems
{
    public class DropItemSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InventoryComponent, DropComponent> filter;

        private IScoreService scoreService;
        private EcsWorld world;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);
                ref var stack = ref filter.Get1(i);

                if (!stack.IsEmpty)
                {
                    stack.Stack.RemoveLast();

                    scoreService.SetScore(scoreService.Score.Value + 1);
                }

                entity.Del<DropComponent>();
            }
        }
    }
}