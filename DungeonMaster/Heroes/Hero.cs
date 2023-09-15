using DungeonMaster.Enums;
using DungeonMaster.Items;

namespace DungeonMaster.Heroes
{
    /// <summary>
    /// Represents a generic hero.
    /// </summary>
    public abstract class Hero
    {
        // Basic hero properties
        public string Name { get; private set; }
        public int Level { get; private set; } = 1;

        // Hero's equipment mapped by slot type
        public Dictionary<Slot, Item> Equipment { get; private set; }

        // Hero's attributes affected by level
        public HeroAttribute LevelAttributes { get; protected set; }

        // Type of the hero
        public HeroType Type { get; protected set; }

        // Computed property to get the hero's primary damage attribute
        public int DamagingAttribute => GetDamagingAttribute();

        // Lists of valid weapon and armor types for the hero
        public IReadOnlyList<WeaponType> ValidWeaponTypes { get; }
        public IReadOnlyList<ArmorType> ValidArmorTypes { get; }

        // Hero constructor
        public Hero(string name, HeroType type, IReadOnlyList<WeaponType> validWeaponTypes, IReadOnlyList<ArmorType> validArmorTypes)
        {
            Name = name;
            Type = type;
            ValidWeaponTypes = validWeaponTypes;
            ValidArmorTypes = validArmorTypes;

            // Initializing hero's equipment with empty slots
            Equipment = new Dictionary<Slot, Item>
            {
                { Slot.Weapon, null },
                { Slot.Head, null },
                { Slot.Body, null },
                { Slot.Legs, null }
            };
        }

        // Increases the hero's level
        public void LevelUp()
        {
            Level++;
            GainAttributes();
        }

        // Abstract method for subclasses to implement the logic for gaining attributes when leveling up
        protected abstract void GainAttributes();

        // Abstract method for subclasses to determine the hero's primary damage attribute
        protected abstract int GetDamagingAttribute();

        // Equip an item to the hero
        public void Equip(Item item, Slot? slot = null)
        {
            // Check if the hero meets the required level to equip the item
            if (Level < item.RequiredLevel)
            {
                throw new InvalidOperationException($"This hero does not meet the required level to equip {item.Name}.");
            }

            // Equip weapon
            if (item is Weapon weapon && ValidWeaponTypes.Contains(weapon.WeaponType))
            {
                if (slot.HasValue && slot.Value != Slot.Weapon)
                {
                    throw new InvalidOperationException($"Weapons can only be equipped in the Weapon slot.");
                }
                Equipment[Slot.Weapon] = weapon;
            }
            // Equip armor
            else if (item is Armor armor && ValidArmorTypes.Contains(armor.ArmorType))
            {
                if (!slot.HasValue || slot.Value != armor.Slot)
                {
                    throw new InvalidOperationException($"Invalid slot for equipping {item.Name}.");
                }
                Equipment[armor.Slot] = armor;
            }
            else
            {
                throw new InvalidOperationException($"This hero cannot equip {item.Name}.");
            }
        }

        // Calculates the hero's total attributes including those from equipped items
        public HeroAttribute TotalAttributes()
        {
            HeroAttribute totalAttributes = new HeroAttribute(LevelAttributes.Strength, LevelAttributes.Dexterity, LevelAttributes.Intelligence);

            foreach (var item in Equipment.Values)
            {
                if (item is Armor armor)
                {
                    totalAttributes.IncreaseStrength(armor.ArmorAttributes.Strength);
                    totalAttributes.IncreaseDexterity(armor.ArmorAttributes.Dexterity);
                    totalAttributes.IncreaseIntelligence(armor.ArmorAttributes.Intelligence);
                }
            }

            return totalAttributes;
        }

        // Calculates the hero's total damage including bonuses from equipment
        public int Damage()
        {
            int totalWeaponDamage = 0;
            foreach (Item item in Equipment.Values)
            {
                if (item is Weapon weapon)
                {
                    totalWeaponDamage += weapon.WeaponDamage;
                }
            }
            return totalWeaponDamage * (1 + DamagingAttribute / 100);
        }

        // Display basic information about the hero on the console
        public void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Class: {Type}");
            Console.WriteLine($"Strength: {LevelAttributes.Strength}");
            Console.WriteLine($"Dexterity: {LevelAttributes.Dexterity}");
            Console.WriteLine($"Intelligence: {LevelAttributes.Intelligence}");
            Console.WriteLine($"Damage: {Damage()}");
        }
    }
}
