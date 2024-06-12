using System.Collections.Generic;
using UnityEngine;
using YohohoChobotov.Game.Items;

namespace YohohoChobotov.Configs.Items
{
    [CreateAssetMenu(fileName = "Items Config", menuName = "Game/Configs/Items Config", order = 0)]
    public class ItemsConfig : ScriptableObject
    {
        [SerializeField] private List<ItemController> items = new();

        public List<ItemController> Items => items;
    }
}