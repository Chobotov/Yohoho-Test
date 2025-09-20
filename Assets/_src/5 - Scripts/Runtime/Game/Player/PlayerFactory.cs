using UnityEngine;
using VContainer;
using VContainer.Unity;
using YohohoChobotov.Configs.Player;

namespace YohohoChobotov.Game.Player
{
    public class PlayerFactory : IFactory<UnitView>
    {
        private IObjectResolver resolver;

        private PlayerConfig config;
        private UnitView unit;

        [Inject]
        public void Inject(IObjectResolver resolver, PlayerConfig config)
        {
            this.resolver = resolver;
            this.config = config;
        }

        public UnitView Create(Vector3 spawnPos)
        {
            unit = resolver.Instantiate(
                config.UnitPrefab,
                spawnPos,
                Quaternion.identity);

            return unit;
        }
    }
}