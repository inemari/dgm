using DungeonMaster.Heroes;

namespace DungeonMasterTests
{
    public class HeroLevelingTests
    {
        // Test data for different hero types and their expected attributes after leveling up
        public static IEnumerable<object[]> HeroLevelingData()
        {
            // Each object[] contains data for a hero type
            // Format: HeroType, ExpectedStrength, ExpectedDexterity, ExpectedIntelligence
            yield return new object[] { typeof(Wizard), 2, 2, 13 };
            yield return new object[] { typeof(Archer), 2, 12, 2 };
            yield return new object[] { typeof(Barbarian), 8, 4, 2 };
            yield return new object[] { typeof(Swashbuckler), 3, 10, 2 };
        }

        // Tests if leveling up a hero increases their attributes as expected.
        [Theory]
        [MemberData(nameof(HeroLevelingData))]
        public void LevelUp_ShouldIncreaseAttributes(Type heroType, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, "TestHero");
            hero.LevelUp();
            Assert.Equal(expectedStrength, hero.LevelAttributes.Strength);
            Assert.Equal(expectedDexterity, hero.LevelAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, hero.LevelAttributes.Intelligence);
        }

        // Tests if leveling up a hero increases their level by one.
        [Theory]
        [MemberData(nameof(HeroLevelingData))]
        public void LevelUp_ShouldIncreaseLevel(Type heroType, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, "TestHero");
            var initialLevel = hero.Level;
            hero.LevelUp();
            Assert.Equal(initialLevel + 1, hero.Level);
        }
    }
}
