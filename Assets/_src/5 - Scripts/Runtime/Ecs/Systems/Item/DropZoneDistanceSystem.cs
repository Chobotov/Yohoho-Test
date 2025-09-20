using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;

namespace YohohoChobotov.Ecs.Systems
{
    public class DropZoneDistanceSystem : IEcsRunSystem
    {
        private readonly EcsFilter<UnitComponent, InventoryComponent> playerFilter;
        private readonly EcsFilter<LevelComponent> levelFilter;

        private EcsWorld world;

        public void Run()
        {
            foreach (var i in levelFilter)
            {
                ref var level = ref levelFilter.Get1(i);

                var dropZone = level.Level.DropZone;

                foreach (var ii in playerFilter)
                {
                    ref var playerEntity = ref playerFilter.GetEntity(ii);
                    ref var player = ref playerFilter.Get1(ii);
                    ref var stack = ref playerFilter.Get2(ii);

                    var playerPosition = player.Unit.transform.position;

                    if (IsInsideBox(playerPosition, dropZone) && !stack.IsEmpty)
                    {
                        playerEntity.Get<DropComponent>();
                    }
                }
            }
        }
        
        private bool IsInsideBox(Vector3 point, BoxCollider box, Vector3 margin = default, bool marginIsWorld = true)
        {
            if (box == null)
            {
                return false;
            }

            var localPos = box.transform.InverseTransformPoint(point);

            if (marginIsWorld && box.transform.lossyScale != Vector3.one)
            {
                var boxTransform = box.transform;

                var pointPlusX = box.transform.InverseTransformPoint(point + boxTransform.right);
                var pointPlusY = box.transform.InverseTransformPoint(point + boxTransform.up);
                var pointPlusZ = box.transform.InverseTransformPoint(point + boxTransform.forward);

                margin.x *= Vector3.Distance(localPos, pointPlusX);
                margin.y *= Vector3.Distance(localPos, pointPlusY);
                margin.z *= Vector3.Distance(localPos, pointPlusZ);
            }

            if (localPos.x - box.center.x >= -box.size.x * 0.5f - margin.x && localPos.x - box.center.x <= box.size.x * 0.5f + margin.x)
            {
                if (localPos.y - box.center.y >= -box.size.y * 0.5f - margin.y && localPos.y - box.center.y <= box.size.y * 0.5f + margin.y)
                {
                    if (localPos.z - box.center.z >= -box.size.z * 0.5f - margin.z && localPos.z - box.center.z <= box.size.z * 0.5f + margin.z)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}