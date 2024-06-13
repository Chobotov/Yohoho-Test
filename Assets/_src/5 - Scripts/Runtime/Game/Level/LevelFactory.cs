using UnityEngine;
using VContainer;
using VContainer.Unity;
using YohohoChobotov.Services.Levels;

namespace YohohoChobotov.Game.Levels
{
    public class LevelFactory : MonoBehaviour
    {
        private ILevelService service;
        private IObjectResolver resolver;

        private LevelController levelField;

        public LevelController LevelField => levelField;

        [Inject]
        public void Inject(IObjectResolver resolver, ILevelService service)
        {
            this.resolver = resolver;
            this.service = service;
        }

        public LevelController CreateLevelField()
        {
            var field = service.GetLevelField();

            levelField = resolver.Instantiate(field, transform);

            return levelField;
        }

        public void ClearField()
        {
            Destroy(levelField.gameObject);
        }
    }
}