using UniRx;
using YohohoChobotov.Game.Items;

namespace YohohoChobotov.Services
{
    public interface IStackService
    {
        IReadOnlyReactiveCollection<ItemController> Items { get; }

        void Add(ItemController item);
        void RemoveLast(int count);
        void Clear();

        int GetMaxCount();
    }
}