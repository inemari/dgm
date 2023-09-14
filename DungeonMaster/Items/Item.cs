using DungeonMaster.Enums;

namespace DungeonMaster.Items
{
    /// <summary>
    /// Represents a generic item.
    /// </summary>
    public abstract class Item
    {
        public string Name { get; set; }
        public int RequiredLevel { get; set; }
        public Slot Slot { get; private set; }

        protected Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }
    }
}