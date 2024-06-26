﻿using System.Collections.Generic;
using UnityEngine;
using VContainer;
using YohohoChobotov.Game.Items;
using YohohoChobotov.Services;

namespace YohohoChobotov.Game.Stack
{
    public class StackController : MonoBehaviour
    {
        private readonly List<ItemController> items = new ();

        private IStackService stackService;

        public int Count => items.Count;

        [Inject]
        public void Inject(IStackService stackService)
        {
            this.stackService = stackService;
        }

        public void Add(ItemController item)
        {
            stackService.Add(item.Info);

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
            stackService.RemoveLast(count: 1);

            var item = items[^1];

            items.Remove(item);

            Destroy(item.gameObject);
        }

        public void Clear()
        {
            for (var i = items.Count - 1; i >= 0; i--)
            {
                RemoveLast();
            }

            stackService.Clear();
        }

        public bool CanAddItem()
        {
            return items.Count < stackService.GetMaxCount();
        }
    }
}