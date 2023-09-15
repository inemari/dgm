using DungeonMaster.Enums;
using DungeonMaster.Heroes;

namespace DungeonMasterTests
{
    /// <summary>
    /// Tests the functionality related to creating heroes.
    /// </summary>
    public class HeroCreation
    {
        // Test data for different hero types and their expected attributes.
        public static IEnumerable<object[]> HeroData()
        {
            // Each object[] contains data for a hero type
            // Format: Type, Name, ExpectedHeroType, ExpectedLevel, ExpectedStrength, ExpectedDexterity, ExpectedIntelligence
            yield return new object[] { typeof(Wizard), "Gandalf", HeroType.Wizard, 1, 1, 1, 8 };
            yield return new object[] { typeof(Archer), "Legolas", HeroType.Archer, 1, 1, 7, 1 };
            yield return new object[] { typeof(Barbarian), "Conan", HeroType.Barbarian, 1, 5, 2, 1 };
            yield return new object[] { typeof(Swashbuckler), "Jack Sparrow", HeroType.Swashbuckler, 1, 2, 6, 1 };
        }

        // Tests if the hero's name is correctly set when created.
        [Theory]
        [MemberData(nameof(HeroData))]
        public void CreateHero_ShouldHaveCorrectName(Type heroType, string name, HeroType expectedHeroType, int expectedLevel, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, name);
            Assert.Equal(name, hero.Name); // Check if the hero's name matches the expected name
        }

        // Tests if the hero's type is correctly set when created.
        [Theory]
        [MemberData(nameof(HeroData))]
        public void CreateHero_ShouldHaveCorrectType(Type heroType, string name, HeroType expectedHeroType, int expectedLevel, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, name);
            Assert.Equal(expectedHeroType, hero.Type); // Check if the hero's type matches the expected type
        }

        // Tests if the hero's level is correctly set when created.
        [Theory]
        [MemberData(nameof(HeroData))]
        public void CreateHero_ShouldHaveCorrectLevel(Type heroType, string name, HeroType expectedHeroType, int expectedLevel, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, name);
            Assert.Equal(expectedLevel, hero.Level); // Check if the hero's level matches the expected level
        }

        // Tests if the hero's strength attribute is correctly set when created.
        [Theory]
        [MemberData(nameof(HeroData))]
        public void CreateHero_ShouldHaveCorrectStrength(Type heroType, string name, HeroType expectedHeroType, int expectedLevel, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, name);
            Assert.Equal(expectedStrength, hero.LevelAttributes.Strength); // Check if the hero's strength attribute matches the expected strength
        }

        // Tests if the hero's dexterity attribute is correctly set when created.
        [Theory]
        [MemberData(nameof(HeroData))]
        public void CreateHero_ShouldHaveCorrectDexterity(Type heroType, string name, HeroType expectedHeroType, int expectedLevel, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, name);
            Assert.Equal(expectedDexterity, hero.LevelAttributes.Dexterity); // Check if the hero's dexterity attribute matches the expected dexterity
        }

        // Tests if the hero's intelligence attribute is correctly set when created.
        [Theory]
        [MemberData(nameof(HeroData))]
        public void CreateHero_ShouldHaveCorrectIntelligence(Type heroType, string name, HeroType expectedHeroType, int expectedLevel, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {
            var hero = (Hero)Activator.CreateInstance(heroType, name);
            Assert.Equal(expectedIntelligence, hero.LevelAttributes.Intelligence); // Check if the hero's intelligence attribute matches the expected intelligence
        }
    }
}
