using DungeonMaster.Enums;

namespace DungeonMaster.Heroes
{    /// <summary>
     /// Represents the Archer hero class.
     /// </summary>
    public class Archer : Hero
    {
        public Archer(string name)
            : base(name, HeroType.Archer, new[] { WeaponType.Bows }, new[] { ArmorType.Leather, ArmorType.Mail })
        {
            LevelAttributes = new HeroAttribute(1, 7, 1);
        }

        protected override int GetDamagingAttribute() => LevelAttributes.Dexterity;

        protected override void GainAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(5);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}

