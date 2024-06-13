using System.Collections.Generic;
using YohohoChobotov.Game.Stack;

namespace YohohoChobotov.Ecs.Components
{
    public struct StackComponent
    {
        public StackController Stack { get; set; }
        public List<ItemComponent> Items { get; set; }

        public bool IsEmpty => Items.Count == 0;

        public void Remove()
        {
            Items.RemoveAt(Items.Count - 1);
            Stack.RemoveLast();
        }
    }
}