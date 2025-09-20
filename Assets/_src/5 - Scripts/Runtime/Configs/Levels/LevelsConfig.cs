using System.Collections.Generic;
using YohohoChobotov.Game.Levels;
using UnityEngine;

namespace YohohoChobotov.Configs.Levels
{
    [CreateAssetMenu(fileName = "Levels Config", menuName = "Game/Configs/Levels Config", order = 0)]
    public class LevelsConfig : Config
    {
        [SerializeField] private List<LevelView> levels = new();

        public LevelView GetLevelField(int level)
        {
            if (level < 0 || level >= levels.Count) return null;

            return levels[level];
        }
    }
}