using UniRx;

namespace YohohoChobotov.Services
{
    public interface IStackService
    {
        IReadOnlyReactiveCollection<ItemInfo> Items { get; }

        void Add(ItemInfo item);
        void RemoveLast(int count);
        void Clear();

        int GetMaxCount();
    }
}