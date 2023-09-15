using DungeonMaster.Enums;
using DungeonMaster.Heroes;

namespace DungeonMaster.Items
{
    /// <summary>
    /// Represents an armor that can be equipped by heroes.
    /// </summary>
    public class Armor : Item
    {
        // Gets or sets the type of the armor (e.g., leather, mail, etc.).
        public ArmorType ArmorType { get; set; }

        // Gets the attribute boosts provided by the armor.
        public HeroAttribute ArmorAttributes { get; private set; }

        // Constructor initializing an armor with its details and assigns attributes based on the hero's current level attributes.
        public Armor(string name, int requiredLevel, Slot slot, ArmorType armorType, Hero hero)
            : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            ArmorAttributes = new HeroAttribute(hero.LevelAttributes.Strength, hero.LevelAttributes.Dexterity, hero.LevelAttributes.Intelligence); // Set initial attributes based on hero's level
        }
    }
}
