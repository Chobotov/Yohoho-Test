using UniRx;

namespace YohohoChobotov.Services
{
    public class StackService : IStackService
    {
        private const int MaxCount = 3;

        private readonly ReactiveCollection<ItemInfo> items = new();

        public IReadOnlyReactiveCollection<ItemInfo> Items => items;

        public void Add(ItemInfo item)
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