using YohohoChobotov.Game.Levels;

namespace YohohoChobotov.Services.Levels
{
    public interface ILevelService
    {
        int CurrentLevel { get; }

        LevelController GetLevelField();
    }
}