using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Game.Items;
using YohohoChobotov.Game.Levels;

namespace YohohoChobotov.Ecs.Systems
{
    public class CreateItemSystem : IEcsRunSystem
    {
        private const float CreatePeriod = 3f;

        private EcsWorld world;
        private ItemsFactory factory;
        private LevelFactory levelFactory;

        private float time = 0;

        public void Run()
        {
            if (time >= CreatePeriod)
            {
                time = 0;

                var position = GetRandomPosition();
                factory.CreateRandomItem(position);
            }

            time += Time.deltaTime;
        }

        private Vector3 GetRandomPosition()
        {
            var collider = levelFactory.LevelField.BoxCollider;

            var colliderBounds = collider.bounds;
            var colliderCenter = colliderBounds.center;

            var randomX = Random.Range(colliderCenter.x - colliderBounds.extents.x, colliderCenter.x + colliderBounds.extents.x);
            var randomZ = Random.Range(colliderCenter.z - colliderBounds.extents.z, colliderCenter.z + colliderBounds.extents.z);
            var y = collider.size.y;

            var randomPos = new Vector3(randomX, y, randomZ);

            return randomPos;
        }
    }
}