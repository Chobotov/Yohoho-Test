using System.Collections.Generic;
using UnityEngine;
using VContainer;
using YohohoChobotov.App;
using YohohoChobotov.Game.Items;

namespace YohohoChobotov.Game.Stack
{
    public class StackController : MonoBehaviour
    {
        private const int MaxCount = 5;

        private List<ItemController> items = new ();
        private EcsStartup ecs;

        public int Count => items.Count;

        [Inject]
        public void Inject(EcsStartup ecs)
        {
            this.ecs = ecs;
        }
        
        private void Add(ItemController item)
        {
            if (items.Count >= MaxCount)
            {
                return;
            }

            items.Add(item);

            var itemTransform = item.transform;

            itemTransform.SetParent(transform);
            itemTransform.localPosition = new Vector3(0, item.Render.localScale.y, 0) * items.Count;
        }

        private void RemoveLast()
        {
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
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<ItemController>(out var item))
            {
                Add(item);
            }
        }
    }
}