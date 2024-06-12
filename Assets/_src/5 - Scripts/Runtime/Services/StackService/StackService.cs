using UniRx;
using YohohoChobotov.Game.Items;

namespace YohohoChobotov.Services
{
    public class StackService : IStackService
    {
        private const int MaxCount = 3;

        private readonly ReactiveCollection<ItemController> items = new();

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