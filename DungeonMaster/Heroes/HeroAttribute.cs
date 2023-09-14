namespace DungeonMaster.Heroes
{
    /// <summary>
    /// Represents the attributes of a hero.
    /// </summary>
    public class HeroAttribute
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Intelligence { get; private set; }

        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public void IncreaseStrength(int amount) => Strength += amount;
        public void IncreaseDexterity(int amount) => Dexterity += amount;
        public void IncreaseIntelligence(int amount) => Intelligence += amount;
    }
}