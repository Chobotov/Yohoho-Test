using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Game;
using YohohoChobotov.Game.Levels;

namespace YohohoChobotov.Ecs.Systems
{
    public class CreateItemSystem : IEcsRunSystem
    {
        private const float CreatePeriod = 3f;

        private readonly EcsFilter<LevelComponent> filter;

        private EcsWorld world;
        private GameState state;

        private float time;

        public void Run()
        {
            foreach (var i in filter)
            {
                var component = filter.Get1(i);
                var level = component.Level;

                if (time >= CreatePeriod)
                {
                    time = 0;

                    var position = GetRandomPosition(level);
                    var item = state.ItemsFactory.Create(position);

                    var entity = world.NewEntity();
                    entity.Get<ItemComponent>().Item = item;
                }

                time += Time.deltaTime;
            }
        }

        private Vector3 GetRandomPosition(LevelView levelView)
        {
            var collider = levelView.BoxCollider;

            var colliderBounds = collider.bounds;
            var colliderCenter = colliderBounds.center;

            var randomX = GetRandomCoordinate(colliderCenter.x, colliderBounds.extents.x);
            var randomZ = GetRandomCoordinate(colliderCenter.z, colliderBounds.extents.z);
            var y = collider.size.y;

            var randomPos = new Vector3(randomX, y, randomZ);

            return randomPos;
        }

        private static float GetRandomCoordinate(float coordinate, float colliderBoundsCoordinate)
        {
            return Random.Range(coordinate - colliderBoundsCoordinate, coordinate + colliderBoundsCoordinate);
        }
    }
}