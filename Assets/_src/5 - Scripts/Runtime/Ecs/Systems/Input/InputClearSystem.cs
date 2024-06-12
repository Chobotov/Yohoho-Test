using Leopotam.Ecs;
using YohohoChobotov.Ecs.Input;

namespace YohohoChobotov.Ecs.Systems
{
    public class InputClearSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InputEvent> filter;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);

                entity.Destroy();
            }
        }
    }
}