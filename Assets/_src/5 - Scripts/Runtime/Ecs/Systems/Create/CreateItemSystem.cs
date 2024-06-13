using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Game;

namespace YohohoChobotov.Ecs.Systems
{
    public class CreateItemSystem : IEcsRunSystem
    {
        private const float CreatePeriod = 3f;

        private EcsWorld world;
        private GameState state;

        private float time = 0;

        public void Run()
        {
            if (time >= CreatePeriod)
            {
                time = 0;

                var position = GetRandomPosition();
                var item = state.ItemsFactory.CreateRandomItem(position);

                var entity = world.NewEntity();
                entity.Get<ItemComponent>().Item = item;
            }

            time += Time.deltaTime;
        }

        private Vector3 GetRandomPosition()
        {
            var collider = state.LevelFactory.LevelField.BoxCollider;

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