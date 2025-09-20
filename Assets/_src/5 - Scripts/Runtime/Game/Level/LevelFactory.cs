using UnityEngine;
using VContainer;
using VContainer.Unity;
using YohohoChobotov.Services.Levels;

namespace YohohoChobotov.Game.Levels
{
    public class LevelFactory : IFactory<LevelView>
    {
        private ILevelService service;
        private IObjectResolver resolver;

        private LevelView levelField;

        [Inject]
        public void Inject(IObjectResolver resolver, ILevelService service)
        {
            this.resolver = resolver;
            this.service = service;
        }

        public LevelView Create(Vector3 position)
        {
            var field = service.GetLevelField();

            levelField = resolver.Instantiate(field);

            return levelField;
        }
    }
}