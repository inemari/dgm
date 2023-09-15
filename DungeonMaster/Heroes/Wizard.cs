using DungeonMaster.Enums;

namespace DungeonMaster.Heroes
{
    /// <summary>
    /// Represents the Wizard hero class.
    /// </summary>
    public class Wizard : Hero
    {
        // Constructor initializing a Wizard with a given name and default attributes.
        public Wizard(string name)
            : base(name, HeroType.Wizard, new[] { WeaponType.Wands, WeaponType.Staffs }, new[] { ArmorType.Cloth })
        {
            LevelAttributes = new HeroAttribute(1, 1, 8);
        }

        // Gets the damaging attribute for Wizard, which is Intelligence.
        protected override int GetDamagingAttribute() => LevelAttributes.Intelligence;

        // Specifies how Wizard gains attributes when leveling up.
        protected override void GainAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(1);
            LevelAttributes.IncreaseIntelligence(5);
        }
    }
}
