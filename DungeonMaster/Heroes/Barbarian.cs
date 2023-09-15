using DungeonMaster.Enums;

namespace DungeonMaster.Heroes
{
    /// <summary>
    /// Represents the Barbarian hero class.
    /// </summary>
    public class Barbarian : Hero
    {
        // Constructor initializing a Barbarian with a given name and default attributes.
        public Barbarian(string name)
            : base(name, HeroType.Barbarian, new[] { WeaponType.Hatchets, WeaponType.Maces, WeaponType.Swords }, new[] { ArmorType.Mail, ArmorType.Plate })
        {
            LevelAttributes = new HeroAttribute(5, 2, 1);
        }

        // Gets the damaging attribute for Barbarian, which is Strength.
        protected override int GetDamagingAttribute() => LevelAttributes.Strength;

        // Specifies how Barbarian gains attributes when leveling up.
        protected override void GainAttributes()
        {
            LevelAttributes.IncreaseStrength(3);
            LevelAttributes.IncreaseDexterity(2);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
