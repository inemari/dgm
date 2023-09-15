using DungeonMaster.Enums;

namespace DungeonMaster.Items
{
    /// <summary>
    /// Represents a generic item.
    /// </summary>
    public abstract class Item
    {
        // Gets or sets the name of the item.
        public string Name { get; set; }

        // Gets or sets the level required to use the item.
        public int RequiredLevel { get; set; }

        // Gets the slot where the item can be equipped.
        public Slot Slot { get; protected set; }

        // Constructor initializing an item with a given name, required level, and slot.
        protected Item(string name, int requiredLevel, Slot slot)
        {
            Name = name;
            RequiredLevel = requiredLevel;
            Slot = slot;
        }
    }
}
