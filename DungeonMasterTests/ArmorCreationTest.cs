using DungeonMaster.Enums;
using DungeonMaster.Heroes;
using DungeonMaster.Items;
namespace DungeonMasterTests
{
    /// <summary>
    /// Tests the functionality related to creating armor items.
    /// </summary>
    public class ArmorCreationTest
    {
        private const string TestArmorName = "TestArmor";
        private const int TestRequiredLevel = 1;

        // Provides test data for armor creation scenarios.
        public static IEnumerable<object[]> ArmorTestData()
        {
            foreach (var heroData in HeroData())
            {
                var heroType = heroData.Item1;
                var heroName = heroData.Item2;
                var attributes = heroData.Item3;


                foreach (var armorType in heroData.Item4)
                {

                    foreach (var attributeCombination in GetAttributeCombinations(attributes))
                    {
                        yield return new object[] { heroType, heroName, armorType, attributes };
                    }
                }
            }
        }

        // Returns hero data including hero type, name, attributes, and valid armor types.
        public static IEnumerable<(Type, string, int[], ArmorType[])> HeroData()
        {
            // Each tuple contains data for a hero type, name, attributes, and valid armor types.
            // Format: (Type, Name, Attributes[], ValidArmorTypes[])
            yield return (typeof(Wizard), "Gandalf", new int[] { 1, 1, 8 }, new ArmorType[] { ArmorType.Cloth });
            yield return (typeof(Archer), "Legolas", new int[] { 1, 7, 1 }, new ArmorType[] { ArmorType.Leather, ArmorType.Mail });
            yield return (typeof(Barbarian), "Conan", new int[] { 5, 2, 1 }, new ArmorType[] { ArmorType.Mail, ArmorType.Plate });
            yield return (typeof(Swashbuckler), "Jack Sparrow", new int[] { 2, 6, 1 }, new ArmorType[] { ArmorType.Leather, ArmorType.Mail });
        }


        // Returns combinations of hero attributes.
        public static IEnumerable<int[]> GetAttributeCombinations(int[] specificAttributes)
        {
            foreach (var attribute in specificAttributes)
            {
                yield return new int[] { attribute };
            }
        }

        // Tests if the armor created has the expected name.
        [Theory]
        [MemberData(nameof(ArmorTestData))]
        public void CreateArmor_ShouldHaveCorrectName(Type heroType, string heroName, ArmorType armorType, int[] attributes)
        {

            var hero = (Hero)Activator.CreateInstance(heroType, heroName);
            var armor = new Armor(TestArmorName, TestRequiredLevel, Slot.Head, armorType, hero);
            Assert.Equal(TestArmorName, armor.Name);
        }

        // Tests if the armor created has the expected attributes based on the hero data.
        [Theory]
        [MemberData(nameof(ArmorTestData))]
        public void CreateArmor_ShouldHaveCorrectAttributes(Type heroType, string heroName, ArmorType armorType, int[] attributes)
        {

            var hero = (Hero)Activator.CreateInstance(heroType, heroName);
            var expectedStrength = attributes[0];
            var expectedDexterity = attributes[1];
            var expectedIntelligence = attributes[2];

            var armor = new Armor(TestArmorName, TestRequiredLevel, Slot.Head, armorType, hero);


            Assert.Equal(expectedStrength, armor.ArmorAttributes.Strength);
            Assert.Equal(expectedDexterity, armor.ArmorAttributes.Dexterity);
            Assert.Equal(expectedIntelligence, armor.ArmorAttributes.Intelligence);
        }
    }
}