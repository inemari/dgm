using DungeonMaster.Enums;

namespace DungeonMaster.Heroes
{
    /// <summary>
    /// Represents the Swashbuckler hero class.
    /// </summary>
    public class Swashbuckler : Hero
    {
        // Constructor initializing a Swashbuckler with a given name and default attributes.
        public Swashbuckler(string name)
            : base(name, HeroType.Swashbuckler, new[] { WeaponType.Daggers, WeaponType.Swords }, new[] { ArmorType.Leather, ArmorType.Mail })
        {
            LevelAttributes = new HeroAttribute(2, 6, 1);
        }

        // Gets the damaging attribute for Swashbuckler, which is Dexterity.
        protected override int GetDamagingAttribute() => LevelAttributes.Dexterity;

        // Specifies how Swashbuckler gains attributes when leveling up.
        protected override void GainAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(4);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
