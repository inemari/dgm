using DungeonMaster.Enums;
using DungeonMaster.Heroes;

namespace DungeonMaster.Items
{
    /// <summary>
    /// Represents an armor item.
    /// </summary>
    public class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public HeroAttribute ArmorAttributes { get; private set; }

        public Armor(string name, int requiredLevel, Slot slot, ArmorType armorType, Hero hero)
            : base(name, requiredLevel, slot)
        {
            ArmorType = armorType;
            ArmorAttributes = new HeroAttribute(hero.LevelAttributes.Strength, hero.LevelAttributes.Dexterity, hero.LevelAttributes.Intelligence); // Set initial attributes based on hero's level
        }

    }
}
