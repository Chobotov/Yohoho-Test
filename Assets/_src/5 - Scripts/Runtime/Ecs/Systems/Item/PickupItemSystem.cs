using Leopotam.Ecs;
using YohohoChobotov.Ecs.Components;

namespace YohohoChobotov.Ecs.Systems
{
    public class PickupItemSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnitComponent, PickupComponent> filter;

        private EcsWorld world;

        public void Run()
        {
            foreach (var i in filter)
            {
                ref var entity = ref filter.GetEntity(i);

                ref var stack = ref entity.Get<InventoryComponent>();
                ref var itemPickup = ref filter.Get2(i);

                var itemPickupItem = itemPickup.Item;

                stack.Stack.Add(itemPickupItem.Item);
                stack.Items.Add(itemPickupItem);

                itemPickupItem.IsTaken = true;
                entity.Del<PickupComponent>();
            }
        }
    }
}