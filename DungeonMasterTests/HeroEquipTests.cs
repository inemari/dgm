using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Items;

namespace DungeonMasterTests
{
    /// <summary>
    /// Test class for evaluating hero equipment functionality.
    /// </summary>
    public class HeroEquipTests
    {
        // Provides test data for various hero instances.
        public static IEnumerable<object[]> HeroData()
        {
            // Each object[] contains data for a different hero instance.
            // Format: Hero
            yield return new object[] { new Wizard("Gandalf") };
            yield return new object[] { new Archer("Legolas") };
            yield return new object[] { new Barbarian("Conan") };
            yield return new object[] { new Swashbuckler("Jack Sparrow") };
        }

        // Generates instances of all hero types for testing.
        private static IEnumerable<Hero> AllHeroTypes()
        {
            return new List<Hero>
            {
                new Wizard("TestWizard"),
                new Archer("TestArcher"),
                new Barbarian("TestBarbarian"),
                new Swashbuckler("TestSwashbuckler")
            };
        }

        // Provides test data for equipping heroes with weapons.
        public static IEnumerable<object[]> GetWeaponTestData()
        {
            foreach (var hero in AllHeroTypes())
            {
                // Each object[] contains data for a hero and a weapon.
                // Format: Hero, Weapon, ExpectedExceptionType (null if no exception is expected)
                yield return new object[] { hero, new Weapon("Sword", 1, WeaponType.Swords, 10), hero.GetType() == typeof(Swashbuckler) || hero.GetType() == typeof(Barbarian) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Weapon("Bow", 1, WeaponType.Bows, 8), hero.GetType() == typeof(Archer) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Weapon("Staff", 1, WeaponType.Staffs, 7), hero.GetType() == typeof(Wizard) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Weapon("Wand", 1, WeaponType.Wands, 5), hero.GetType() == typeof(Wizard) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Weapon("Dagger", 1, WeaponType.Daggers, 6), hero.GetType() == typeof(Swashbuckler) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Weapon("Hatchet", 1, WeaponType.Hatchets, 9), hero.GetType() == typeof(Barbarian) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Weapon("Mace", 1, WeaponType.Maces, 11), hero.GetType() == typeof(Barbarian) ? null : typeof(InvalidOperationException) };
            }
        }

        // Provides test data for equipping heroes with various armor types.
        public static IEnumerable<object[]> GetArmorTestData()
        {
            foreach (var hero in AllHeroTypes())
            {
                // Format: Hero, Armor, ExpectedExceptionType (null if no exception is expected)
                yield return new object[] { hero, new Armor("Robe", 1, Slot.Body, ArmorType.Cloth, new Wizard("DummyWizard")), hero.GetType() == typeof(Wizard) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Armor("LeatherArmor", 1, Slot.Head, ArmorType.Leather, new Archer("DummyArcher")), (hero.GetType() == typeof(Archer) || hero.GetType() == typeof(Swashbuckler)) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Armor("MailArmor", 1, Slot.Head, ArmorType.Mail, new Archer("DummyArcher")), (hero.GetType() == typeof(Archer) || hero.GetType() == typeof(Swashbuckler) || hero.GetType() == typeof(Barbarian)) ? null : typeof(InvalidOperationException) };
                yield return new object[] { hero, new Armor("PlateArmor", 1, Slot.Body, ArmorType.Plate, new Barbarian("DummyBarbarian")), hero.GetType() == typeof(Barbarian) ? null : typeof(InvalidOperationException) };
            }
        }

        // Provides test data for equipping heroes with weapons that may trigger exceptions due to level restrictions.
        public static IEnumerable<object[]> GetWeaponTestDataWithLevelRestrictions()
        {
            foreach (var hero in AllHeroTypes())
            {
                // Each object[] contains data for a hero and a weapon.
                // Format: Hero, Weapon, ExpectedExceptionType (null if no exception is expected)
                yield return new object[] { hero, new Weapon("HighLevelWeapon", 10, WeaponType.Staffs, 50) };
            }
        }

        // Provides test data for equipping heroes with armor that may trigger exceptions due to level restrictions.
        public static IEnumerable<object[]> GetArmorTestDataWithLevelRestrictions()
        {
            foreach (var hero in AllHeroTypes())
            {
                // Format: Hero, Armor, ExpectedExceptionType (null if no exception is expected)
                yield return new object[] { hero, new Armor("HighLevelArmor", 10, Slot.Body, ArmorType.Leather, hero) };
            }
        }

        // Tests if the correct exception is thrown when a hero with insufficient level attempts to equip a weapon.
        [Theory]
        [MemberData(nameof(GetWeaponTestDataWithLevelRestrictions))]
        public void HeroCannotEquipWeaponDueToLevel(Hero hero, Weapon weapon)
        {
            Assert.Throws<InvalidOperationException>(() => hero.Equip(weapon));
        }

        // Tests if the correct exception is thrown when a hero with insufficient level attempts to equip armor.
        [Theory]
        [MemberData(nameof(GetArmorTestDataWithLevelRestrictions))]
        public void HeroCannotEquipArmorDueToLevel(Hero hero, Armor armor)
        {
            Assert.Throws<InvalidOperationException>(() => hero.Equip(armor));
        }

        // Tests if a hero can equip a weapon or if it throws an exception as expected.
        [Theory]
        [MemberData(nameof(GetWeaponTestData))]
        public void HeroShouldEquipWeapon(Hero hero, Weapon weapon, Type expectedExceptionType)
        {
            if (weapon is Weapon w)
            {
                AssertExceptionType(() => hero.Equip(w, Slot.Weapon), expectedExceptionType);
            }
            else
            {
                AssertExceptionType(() => hero.Equip(weapon), expectedExceptionType);
            }
        }

        // Tests if a hero can equip armor or if it throws an exception as expected.
        [Theory]
        [MemberData(nameof(GetArmorTestData))]
        public void HeroShouldEquipArmor(Hero hero, Armor armor, Type expectedExceptionType)
        {
            if (armor is Armor a)
            {
                AssertExceptionType(() => hero.Equip(a, a.Slot), expectedExceptionType);
            }
            else
            {
                AssertExceptionType(() => hero.Equip(armor), expectedExceptionType);
            }
        }

        // Asserts the expected exception type when performing an action.
        private void AssertExceptionType(Action action, Type expectedExceptionType)
        {
            var exception = Record.Exception(action);
            if (expectedExceptionType == null)
                Assert.Null(exception);
            else
                Assert.IsType(expectedExceptionType, exception);
        }
    }
}
