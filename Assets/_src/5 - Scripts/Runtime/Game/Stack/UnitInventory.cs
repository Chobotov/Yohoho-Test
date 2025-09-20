using System.Collections.Generic;
using UnityEngine;
using YohohoChobotov.Game.Items;

namespace YohohoChobotov.Game.Stack
{
    public class UnitInventory : MonoBehaviour
    {
        private const int MaxCount = 3;

        private readonly List<Item> items = new ();

        public void Add(Item item)
        {
            if (!CanAddItem())
            {
                return;
            }

            items.Add(item);

            var itemTransform = item.transform;

            itemTransform.SetParent(transform);
            itemTransform.localPosition = new Vector3(0, item.Render.localScale.y, 0) * items.Count;
        }

        public void RemoveLast()
        {
            var item = items[^1];

            items.Remove(item);

            Destroy(item.gameObject);
        }

        public bool CanAddItem()
        {
            return items.Count < MaxCount;
        }
    }
}