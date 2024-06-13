using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;

namespace YohohoChobotov.Ecs.Systems
{
    public class PickupItemSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerComponent, PickupComponent> filter;

        private EcsWorld world;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);

                ref var stack = ref entity.Get<StackComponent>();
                ref var itemPickup = ref filter.Get2(i);

                stack.Stack.Add(itemPickup.Item.Item);
                stack.Items.Add(itemPickup.Item);

                entity.Del<PickupComponent>();
            }
        }
    }
}