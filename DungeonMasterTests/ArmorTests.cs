using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Items;

namespace DungeonMaster.Tests
{
    public class ArmorTests
    {
        // Test data for different armors and their expected attributes
        public static IEnumerable<object[]> ArmorData()
        {
            var testDataProvider = new TestDataProvider(); // Create an instance of TestDataProvider

            // Retrieve hero data using the GetHeroData method
            foreach (var heroData in TestDataProvider.GetHeroData())
            {
                // Extract hero data
                Type heroType = (Type)heroData[0];
                string name = (string)heroData[1];

                // Create a hero instance based on the data
                Hero hero = (Hero)Activator.CreateInstance(heroType, name);

                // Continue with your armor data setup
                yield return new object[] { "Plate Helmet", 2, Slot.Head, ArmorType.Plate, hero };
            }
        }



        [Theory]
        [MemberData(nameof(ArmorData))]
        public void CreateArmor_ShouldHaveCorrectName(string name, int requiredLevel, Slot slot, ArmorType armorType, Hero hero)
        {
            // Arrange
            Armor armor = new Armor(name, requiredLevel, slot, armorType, hero);

            // Assert
            Assert.Equal(name, armor.Name); // Check if the armor's name matches the expected name
        }

        [Theory]
        [MemberData(nameof(ArmorData))]
        public void CreateArmor_ShouldHaveCorrectRequiredLevel(string name, int requiredLevel, Slot slot, ArmorType armorType, Hero hero)
        {
            // Arrange
            Armor armor = new Armor(name, requiredLevel, slot, armorType, hero);

            // Assert
            Assert.Equal(requiredLevel, armor.RequiredLevel); // Check if the armor's required level matches the expected level
        }

        [Theory]
        [MemberData(nameof(ArmorData))]
        public void CreateArmor_ShouldHaveCorrectSlot(string name, int requiredLevel, Slot slot, ArmorType armorType, Hero hero)
        {
            // Arrange
            Armor armor = new Armor(name, requiredLevel, slot, armorType, hero);

            // Assert
            Assert.Equal(slot, armor.Slot); // Check if the armor's slot matches the expected slot
        }

        [Theory]
        [MemberData(nameof(ArmorData))]
        public void CreateArmor_ShouldHaveCorrectArmorType(string name, int requiredLevel, Slot slot, ArmorType armorType, Hero hero)
        {
            // Arrange
            Armor armor = new Armor(name, requiredLevel, slot, armorType, hero);

            // Assert
            Assert.Equal(armorType, armor.ArmorType); // Check if the armor's type matches the expected type
        }

        [Theory]
        [MemberData(nameof(ArmorData))]
        public void CreateArmor_ShouldHaveCorrectArmorAttributes(string name, int requiredLevel, Slot slot, ArmorType armorType, Hero hero)
        {
            // Arrange
            Armor armor = new Armor(name, requiredLevel, slot, armorType, hero);

            // Assert
            Assert.Equal(hero.LevelAttributes.Strength, armor.ArmorAttributes.Strength); // Check if the armor's strength attribute matches the expected strength
            Assert.Equal(hero.LevelAttributes.Dexterity, armor.ArmorAttributes.Dexterity); // Check if the armor's dexterity attribute matches the expected dexterity
            Assert.Equal(hero.LevelAttributes.Intelligence, armor.ArmorAttributes.Intelligence); // Check if the armor's intelligence attribute matches the expected intelligence
        }
    }
}
