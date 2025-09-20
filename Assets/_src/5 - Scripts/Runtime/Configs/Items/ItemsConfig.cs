using System.Collections.Generic;
using UnityEngine;
using YohohoChobotov.Game.Items;

namespace YohohoChobotov.Configs.Items
{
    [CreateAssetMenu(fileName = "Items Config", menuName = "Game/Configs/Items Config", order = 0)]
    public class ItemsConfig : Config
    {
        [SerializeField] private List<Item> items = new();

        public List<Item> Items => items;
    }
}