using UnityEngine;
using VContainer;
using YohohoChobotov.Configs.Items;
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

        public void CreateRandomItem(Vector3 position)
        {
            var itemPrefab = config.Items.GetRandomItem();

            Instantiate(itemPrefab, position, Quaternion.identity, transform);
        }
    }
}