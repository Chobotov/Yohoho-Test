using Leopotam.Ecs;
using UnityEngine;
using YohohoChobotov.Ecs.Components;
using YohohoChobotov.Game;

namespace YohohoChobotov.Ecs.Systems
{
    public class CreateLevelSystem : IEcsInitSystem
    {
        private EcsWorld world;
        private GameState state;

        public void Init()
        {
            var level = state.LevelFactory.Create(Vector3.zero);
            var newEntity = world.NewEntity();

            newEntity.Get<LevelComponent>().Level = level;
        }
    }
}