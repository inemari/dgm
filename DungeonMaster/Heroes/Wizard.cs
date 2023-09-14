using DungeonMaster.Enums;

namespace DungeonMaster.Heroes
{
    public class Wizard : Hero
    {


        public Wizard(string name) : base(name, HeroType.Wizard, new[] { WeaponType.Wands, WeaponType.Staffs }, new[] { ArmorType.Cloth })
        {
            LevelAttributes = new HeroAttribute(1, 1, 8);
        }

        protected override int GetDamagingAttribute() => LevelAttributes.Intelligence;

        protected override void GainAttributes()
        {
            LevelAttributes.IncreaseStrength(1);
            LevelAttributes.IncreaseDexterity(1);
            LevelAttributes.IncreaseIntelligence(5);
        }
    }
}
