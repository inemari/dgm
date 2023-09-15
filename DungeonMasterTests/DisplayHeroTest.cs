using DungeonMaster.Enums;
using DungeonMaster.Heroes;

namespace DungeonMasterTests
{
    /// <summary>
    /// Tests the functionality related to displaying hero information.
    /// </summary>
    public class DisplayHeroTest
    {
        #region HeroTestData
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
        #endregion

        // Tests if the hero's information is displayed correctly.
        [Theory]
        [MemberData(nameof(HeroData))]
        public void Display_ShouldDisplayCorrectInfo(Type heroType, string name, HeroType expectedHeroType, int expectedLevel, int expectedStrength, int expectedDexterity, int expectedIntelligence)
        {

            var hero = (Hero)Activator.CreateInstance(heroType, name);
            var displayInfo = CaptureConsoleOutput(() => hero.Display());

            Assert.Contains($"Name: {name}", displayInfo);
            Assert.Contains($"Level: {expectedLevel}", displayInfo);
            Assert.Contains($"Class: {expectedHeroType}", displayInfo);
            Assert.Contains($"Strength: {expectedStrength}", displayInfo);
            Assert.Contains($"Dexterity: {expectedDexterity}", displayInfo);
            Assert.Contains($"Intelligence: {expectedIntelligence}", displayInfo);
            Assert.Contains($"Damage:", displayInfo);
        }

        // Helper method to capture console output
        private string CaptureConsoleOutput(Action action)
        {
            var originalOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                action.Invoke();
                return writer.ToString().Trim();
            }
        }

    }
}
