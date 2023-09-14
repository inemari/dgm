using DungeonMaster.Enums;
using DungeonMaster.Heroes;

namespace DungeonMaster.Tests
{
    public class TestDataProvider
    {
        // Test data for different hero types and their expected attributes
        public static IEnumerable<object[]> GetHeroData()
        {
            yield return new object[] { typeof(Wizard), "Gandalf", HeroType.Wizard, 1, 1, 1, 8 };
            yield return new object[] { typeof(Archer), "Legolas", HeroType.Archer, 1, 1, 7, 1 };
            yield return new object[] { typeof(Barbarian), "Conan", HeroType.Barbarian, 1, 5, 2, 1 };
            yield return new object[] { typeof(Swashbuckler), "Jack Sparrow", HeroType.Swashbuckler, 1, 2, 6, 1 };
        }

        // Test data for different armor types
        public static IEnumerable<object[]> ArmorTypeData()
        {
            yield return new object[] { "Plate Helmet", Slot.Head, ArmorType.Plate };
            yield return new object[] { "Leather Vest", Slot.Body, ArmorType.Leather };

        }
    }
}
