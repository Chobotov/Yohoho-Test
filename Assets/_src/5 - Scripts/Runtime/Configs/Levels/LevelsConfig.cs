using System.Collections.Generic;
using YohohoChobotov.Game.Levels;
using UnityEngine;

namespace YohohoChobotov.Configs.Levels
{
    [CreateAssetMenu(fileName = "Levels Config", menuName = "Game/Configs/Levels Config", order = 0)]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private List<LevelController> levels = new();

        public LevelController GetLevelField(int level)
        {
            if (level < 0 || level >= levels.Count) return null;

            return levels[level];
        }
    }
}