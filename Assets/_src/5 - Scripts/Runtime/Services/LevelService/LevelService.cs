using YohohoChobotov.Configs.Levels;
using YohohoChobotov.Game.Levels;

namespace YohohoChobotov.Services.Levels
{
    public class LevelService : ILevelService
    {
        private readonly LevelsConfig config;

        public int CurrentLevel { get; } = 0;

        public LevelService(LevelsConfig config)
        {
            this.config = config;
        }

        public LevelView GetLevelField()
        {
            return config.GetLevelField(CurrentLevel);
        }
    }
}