using UnityEngine;
using VContainer;
using YohohoChobotov.Services.Levels;

namespace YohohoChobotov.Game.Levels
{
    public class LevelFactory : MonoBehaviour
    {
        private ILevelService service;

        private LevelController levelField;

        public LevelController LevelField => levelField;

        [Inject]
        public void Inject(ILevelService service)
        {
            this.service = service;
        }

        public void CreateLevelField()
        {
            var field = service.GetLevelField();
            levelField = Instantiate(field, transform);
        }

        public void ClearField()
        {
            Destroy(levelField.gameObject);
        }
    }
}