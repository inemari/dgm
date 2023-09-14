using DungeonMaster.Enums;
using DungeonMaster.Items;

namespace DungeonMaster.Tests
{
    public class WeaponTests
    {
        #region WeaponTestData
        // Test data for different weapons and their expected attributes
        public static IEnumerable<object[]> WeaponData()
        {
            // Each object[] contains data for a weapon
            // Format: Name, RequiredLevel, WeaponType, WeaponDamage, Slot
            yield return new object[] { "Sword of Strength", 1, WeaponType.Swords, 10, Slot.Weapon };
            yield return new object[] { "Bow of Precision", 3, WeaponType.Bows, 15, Slot.Weapon };
        }
        #endregion
        #region WeaponName
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectName(string name, int requiredLevel, WeaponType weaponType, int weaponDamage, Slot slot)
        {
            // Arrange
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);

            // Assert
            Assert.Equal(name, weapon.Name); // Check if the weapon's name matches the expected name
        }
        #endregion
        #region WeaponRequiredLevel
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectRequiredLevel(string name, int requiredLevel, WeaponType weaponType, int weaponDamage, Slot slot)
        {
            // Arrange
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);

            // Assert
            Assert.Equal(requiredLevel, weapon.RequiredLevel); // Check if the weapon's required level matches the expected level
        }
        #endregion
        #region WeaponType
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectWeaponType(string name, int requiredLevel, WeaponType weaponType, int weaponDamage, Slot slot)
        {
            // Arrange
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);

            // Assert
            Assert.Equal(weaponType, weapon.WeaponType); // Check if the weapon's type matches the expected type
        }
        #endregion
        #region WeaponDamage
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectWeaponDamage(string name, int requiredLevel, WeaponType weaponType, int weaponDamage, Slot slot)
        {
            // Arrange
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);

            // Assert
            Assert.Equal(weaponDamage, weapon.WeaponDamage); // Check if the weapon's damage matches the expected damage
        }
        #endregion
        #region WeaponSlot
        [Theory]
        [MemberData(nameof(WeaponData))]
        public void CreateWeapon_ShouldHaveCorrectSlot(string name, int requiredLevel, WeaponType weaponType, int weaponDamage, Slot slot)
        {
            // Arrange
            Weapon weapon = new Weapon(name, requiredLevel, weaponType, weaponDamage);

            // Assert
            Assert.Equal(slot, weapon.Slot); // Check if the weapon's slot matches the expected slot
        }
        #endregion
    }
}
