using UnityEngine;
using VContainer;
using YohohoChobotov.Configs.Items;
using YohohoChobotov.Utills;

namespace YohohoChobotov.Game.Items
{
    public class ItemsFactory : IFactory<Item>
    {
        private ItemsConfig config;

        [Inject]
        public void Inject(ItemsConfig config)
        {
            this.config = config;
        }

        public Item Create(Vector3 position)
        {
            var itemPrefab = config.Items.GetRandomItem();
            var item = Object.Instantiate(itemPrefab, position, Quaternion.identity);

            return item;
        }
    }
}