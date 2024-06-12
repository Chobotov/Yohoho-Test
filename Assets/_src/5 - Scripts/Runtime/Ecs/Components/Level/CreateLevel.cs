using YohohoChobotov.Game.Levels;

namespace YohohoChobotov.Ecs.Level
{
    public struct CreateLevel
    {
        public int Level { get; set; }
        public LevelFactory Factory { get; set; }
    }
}