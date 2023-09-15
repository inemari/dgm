using DungeonMaster.Enums;

namespace DungeonMaster.Heroes
{
    /// <summary>
    /// Represents the Archer hero class.
    /// </summary>
    public class Archer : Hero
    {
        // Constructor initializing an Archer with a given name and default attributes.
        public Archer(string name)
            : base(name, HeroType.Archer, new[] { WeaponType.Bows }, new[] { ArmorType.Leather, ArmorType.Mail })
        {
            LevelAttributes = new HeroAttribute(1, 7, 1);
        }

        // Gets the damaging attribute for Archer, which is Dexterity.
        protected override int GetDamagingAttribute() => LevelAttributes.Dexterity;

        // Specifies how Archer gains attributes when leveling up.
        protected override void GainAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(5);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
