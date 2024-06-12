using System.Collections.Generic;
using UniRx;
using UnityEngine;
using YohohoChobotov.Game.Items;

namespace YohohoChobotov.Services
{
    public class StackService : IStackService
    {
        private const int MaxCount = 3;

        private ReactiveCollection<ItemController> items = new();

        public IReadOnlyReactiveCollection<ItemController> Items => items;

        public void Add(ItemController item)
        {
            if (items.Count >= MaxCount)
            {
                return;
            }

            items.Add(item);
        }

        public void RemoveLast(int count)
        {
            for (var i = 0; i < count; i++)
            {
                var item = items[^1];

                items.Remove(item);

                Object.Destroy(item.gameObject);
            }
        }

        public void Clear()
        {
            RemoveLast(items.Count);
        }

        public int GetMaxCount()
        {
            return MaxCount;
        }
    }
}