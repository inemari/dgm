using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Items;

namespace DungeonMaster.Tests
{
    public class HeroEquipTests
    {
        [Theory]
        [MemberData(nameof(TestDataProvider.GetHeroData))]
        public void Hero_ShouldEquipValidArmor(Type heroType, string name, HeroType expectedHeroType, int expectedLevel, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            // Arrange
            var hero = (Hero)Activator.CreateInstance(heroType, name);
            var validArmor = new Armor("Valid Armor", 1, Slot.Body, ArmorType.Leather, hero);

            // Act
            hero.Equip(validArmor);

            // Assert
            Assert.Equal(validArmor, hero.Equipment[Slot.Body]);
        }

        [Theory]
        [MemberData(nameof(TestDataProvider.ArmorTypeData))]
        public void Hero_ShouldEquipValidArmorType(string armorName, Slot slot, ArmorType armorType)
        {
            // Arrange
            var hero = new Wizard("Gandalf"); // You can change the hero type here
            var validArmor = new Armor(armorName, 1, slot, armorType, hero);

            // Act
            hero.Equip(validArmor);

            // Assert
            Assert.Equal(validArmor, hero.Equipment[slot]);
        }

        [Theory]
        [InlineData("High-Level Armor", Slot.Body, ArmorType.Leather, 10)] // Specify a high required level
        public void Hero_ShouldThrowExceptionWhenEquippingHighLevelArmor(string armorName, Slot slot, ArmorType armorType, int requiredLevel)
        {
            // Arrange
            var hero = new Wizard("Gandalf"); // You can change the hero type here
            var highLevelArmor = new Armor(armorName, requiredLevel, slot, armorType, hero);

            // Act and Assert
            Assert.Throws<InvalidOperationException>(() => hero.Equip(highLevelArmor));
        }

    }
}
