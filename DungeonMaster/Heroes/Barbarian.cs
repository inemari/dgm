using DungeonMaster.Enums;


namespace DungeonMaster.Heroes
{
    /// <summary>
    /// Represents the Barbarian hero class.
    /// </summary>
    public class Barbarian : Hero
    {
        public Barbarian(string name) : base(name, HeroType.Barbarian, new[] { WeaponType.Hatchets, WeaponType.Maces, WeaponType.Swords }, new[] { ArmorType.Mail, ArmorType.Plate })
        {
            LevelAttributes = new HeroAttribute(5, 2, 1);

        }

        protected override int GetDamagingAttribute() => LevelAttributes.Strength;

        protected override void GainAttributes()
        {
            LevelAttributes.IncreaseStrength(3);
            LevelAttributes.IncreaseDexterity(2);
            LevelAttributes.IncreaseIntelligence(1);
        }
    }
}