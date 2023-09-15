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


        // Constructor with specified attribute values.
        public HeroAttribute(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        // Increases the hero's strength attribute by a specified amount.
        public void IncreaseStrength(int amount) => Strength += amount;


        // Increases the hero's dexterity attribute by a specified amount.
        public void IncreaseDexterity(int amount) => Dexterity += amount;


        // Increases the hero's intelligence attribute by a specified amount.
        public void IncreaseIntelligence(int amount) => Intelligence += amount;

    }
}
