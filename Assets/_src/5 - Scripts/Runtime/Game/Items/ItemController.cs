using UnityEngine;
using YohohoChobotov.Services;

namespace YohohoChobotov.Game.Items
{
    public class ItemController : MonoBehaviour
    {
        [SerializeField] private Transform render;

        private ItemInfo info;

        public Transform Render => render;
        public ItemInfo Info => info;

        public void Init(ItemInfo info)
        {
            this.info = info;
        }
    }
}