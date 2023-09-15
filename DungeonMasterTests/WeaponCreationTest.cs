using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Items;

namespace DungeonMasterTests
{
    public class WeaponCreationTest
    {
        // Provides test data for creating weapons for different hero types.
        public static IEnumerable<object[]> WeaponData()
        {
            foreach (var heroData in HeroData())
            {
                var heroType = heroData.Item1;
                var heroName = heroData.Item2;
                var validWeapons = heroData.Item3;

                foreach (var weaponType in validWeapons)
                {
                    // Format: HeroType, HeroName, WeaponType, WeaponName, RequiredLevel, WeaponDamage
                    yield return new object[] { heroType, heroName, weaponType, "TestWeapon", 1, 10 };
                }
            }
        }

        // Provides data for different hero types and their valid weapon types.
        public static IEnumerable<(Type, string, WeaponType[])> HeroData()
        {   // Each tuple contains data for a hero type.
            // Format: HeroType, HeroName, ValidWeaponTypes
            yield return (typeof(Wizard), "Gandalf", new[] { WeaponType.Staffs, WeaponType.Wands });
            yield return (typeof(Archer), "Legolas", new[] { WeaponType.Bows });
            yield return (typeof(Barbarian), "Conan", new[] { WeaponType.Hatchets, WeaponType.Maces, WeaponType.Swords });
            yield return (typeof(Swashbuckler), "Jack Sparrow", new[] { WeaponType.Daggers, WeaponType.Swords });
        }

        // Tests if creating a weapon results in the correct weapon type for the hero.
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectWeaponType(Type heroType, string heroName, WeaponType weaponType, string name, int requiredLevel, int weaponDamage)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, heroName);
            var weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);
            Assert.Contains(weaponType, hero.ValidWeaponTypes);
        }

        // Tests if creating a weapon results in the correct weapon name.
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectName(Type heroType, string heroName, WeaponType weaponType, string name, int requiredLevel, int weaponDamage)
        {
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);
            Assert.Equal(name, weapon.Name);
        }

        // Tests if creating a weapon results in the correct required level.
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectRequiredLevel(Type heroType, string heroName, WeaponType weaponType, string name, int requiredLevel, int weaponDamage)
        {
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);
            Assert.Equal(requiredLevel, weapon.RequiredLevel);
        }

        // Tests if creating a weapon results in the correct weapon damage.
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectWeaponDamage(Type heroType, string heroName, WeaponType weaponType, string name, int requiredLevel, int weaponDamage)
        {
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);
            Assert.Equal(weaponDamage, weapon.WeaponDamage);
        }
    }
}
