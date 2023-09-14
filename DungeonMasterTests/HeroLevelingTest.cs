using DungeonMaster.Heroes;

namespace DungeonMaster.Tests
{
    public class HeroLevelingTests
    {

        #region TestHeroLevellingData
        // Test data for different hero types and their expected attributes after leveling up
        public static IEnumerable<object[]> HeroLevelingData()
        {
            // Each object[] contains data for a hero type
            // Format: Type, ExpectedStrength, ExpectedDexterity, ExpectedIntelligence
            yield return new object[] { typeof(Wizard), 2, 2, 13 };
            yield return new object[] { typeof(Archer), 2, 12, 2 };
            yield return new object[] { typeof(Barbarian), 8, 4, 2 };
            yield return new object[] { typeof(Swashbuckler), 3, 10, 2 };
        }
        #endregion
        #region AttributeIncrease
        [Theory]
        [MemberData(nameof(HeroLevelingData))]
        public void LevelUp_ShouldIncreaseAttributes(Type heroType, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            // Arrange
            var hero = (Hero)Activator.CreateInstance(heroType, "TestHero");

            // Act
            hero.LevelUp();

            // Assert
            Assert.Equal(expectedStrength, hero.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, hero.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, hero.LevelAttributes.Intelligence);
        }
        #endregion
        #region LevelIncrease
        [Theory]
        [MemberData(nameof(HeroLevelingData))]
        public void LevelUp_ShouldIncreaseLevel(Type heroType, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            // Arrange
            var hero = (Hero)Activator.CreateInstance(heroType, "TestHero");
            var initialLevel = hero.Level;

            // Act
            hero.LevelUp();

            // Assert
            Assert.Equal(initialLevel + 1, hero.Level); // Check if the hero's level increased by one
        }
        #endregion
    }
}