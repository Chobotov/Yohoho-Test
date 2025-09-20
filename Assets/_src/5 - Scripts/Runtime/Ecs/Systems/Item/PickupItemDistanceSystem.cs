using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;

namespace YohohoChobotov.Ecs.Systems
{
    public class PickupItemDistanceSystem : IEcsRunSystem
    {
        private const float PickupDistance = 1f;

        private readonly EcsFilter<UnitComponent, InventoryComponent> playerFilter;
        private readonly EcsFilter<ItemComponent> itemFilter;

        private EcsWorld world;

        public void Run()
        {
            foreach (var i in playerFilter)
            {
                ref var entity = ref playerFilter.GetEntity(i);
                ref var playerComponent = ref playerFilter.Get1(i);
                ref var stackComponent = ref playerFilter.Get2(i);

                var playerController = playerComponent.Unit;

                foreach (var ii in itemFilter)
                {
                    ref var itemEntity = ref itemFilter.Get1(ii);
                    
                    if (itemEntity.IsTaken) continue;

                    var item = itemEntity.Item;

                    var canPickup = CanPickup(playerController.transform.position, item.transform.position);

                    if (canPickup && stackComponent.Stack.CanAddItem())
                    {
                        entity.Get<PickupComponent>().Item = itemEntity;
                    }
                }
            }
        }

        private bool CanPickup(Vector3 playerPosition, Vector3 itemPosition)
        {
            var distance = Vector3.Distance(playerPosition, itemPosition);

            return distance <= PickupDistance;
        }
    }
}