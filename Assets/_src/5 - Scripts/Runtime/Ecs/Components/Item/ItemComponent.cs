using YohohoChobotov.Game.Items;

namespace YohohoChobotov.Ecs.Components
{
    public struct ItemComponent
    {
        public ItemController Item { get; set; }
        public bool IsTaken { get; set; }
    }
}