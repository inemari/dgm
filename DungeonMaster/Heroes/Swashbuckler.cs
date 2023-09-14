using DungeonMaster.Enums;

namespace DungeonMaster.Heroes
{    /// <summary>
     /// Represents the Swashbuckler hero class.
     /// </summary>
    public class Swashbuckler : Hero
    {

        public Swashbuckler(string name) : base(name, HeroType.Swashbuckler, new[] { WeaponType.Daggers, WeaponType.Swords }, new[] { ArmorType.Leather, ArmorType.Mail })
        {
            LevelAttributes = new HeroAttribute(2, 6, 1); // Initial attributes
        }

        protected override int GetDamagingAttribute() => LevelAttributes.Dexterity;

        protected override void GainAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(4);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}
