using System.Collections.Generic;
using YohohoChobotov.Game.Stack;

namespace YohohoChobotov.Ecs.Components
{
    public struct InventoryComponent
    {
        public UnitInventory Stack { get; set; }
        public List<ItemComponent> Items { get; set; }

        public bool IsEmpty => Items.Count == 0;
    }
}