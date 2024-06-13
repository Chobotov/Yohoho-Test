using UnityEngine;
using VContainer;
using YohohoChobotov.Configs.Items;
using YohohoChobotov.Services;
using YohohoChobotov.Utills;

namespace YohohoChobotov.Game.Items
{
    public class ItemsFactory : MonoBehaviour
    {
        private ItemsConfig config;

        [Inject]
        public void Inject(ItemsConfig config)
        {
            this.config = config;
        }

        public ItemController CreateRandomItem(Vector3 position)
        {
            var itemPrefab = config.Items.GetRandomItem();
            var item = Instantiate(itemPrefab, position, Quaternion.identity, transform);

            item.Init(new ItemInfo());

            return item;
        }
    }
}