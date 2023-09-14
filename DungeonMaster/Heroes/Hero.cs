using DungeonMaster.Enums;
using DungeonMaster.Items;

namespace DungeonMaster.Heroes
{
    /// <summary>
    /// Represents a generic hero.
    /// </summary>
    public abstract class Hero
    {
        public string Name { get; private set; }
        public Dictionary<Slot, Item> Equipment { get; private set; }

        public int Level { get; private set; } = 1;
        public HeroAttribute LevelAttributes { get; protected set; }

        public HeroType Type { get; protected set; }
        public int DamagingAttribute => GetDamagingAttribute();
        public IReadOnlyList<WeaponType> ValidWeaponTypes { get; }
        public IReadOnlyList<ArmorType> ValidArmorTypes { get; }

        public Hero(string name, HeroType type, IReadOnlyList<WeaponType> validWeaponTypes, IReadOnlyList<ArmorType> validArmorTypes)
        {
            Name = name;
            Type = type;
            ValidWeaponTypes = validWeaponTypes;
            ValidArmorTypes = validArmorTypes;

            Equipment = new Dictionary<Slot, Item>
            {
                { Slot.Weapon, null },
                { Slot.Head, null },
                { Slot.Body, null },
                { Slot.Legs, null }
            };
        }

        public void LevelUp()
        {
            Level++;
            GainAttributes();
        }

        protected abstract void GainAttributes();
        protected abstract int GetDamagingAttribute();

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
                if (!slot.HasValue || slot.Value == Slot.Weapon)
                {
                    throw new InvalidOperationException($"Invalid slot for equipping armor.");
                }
                Equipment[slot.Value] = armor;

            }
            else
            {
                throw new InvalidOperationException($"This hero cannot equip {item.Name}.");
            }

        }

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

        public void Display()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Class: {Type}");
            Console.WriteLine($"Strength: {LevelAttributes.Strength}");
            Console.WriteLine($"Dexterity: {LevelAttributes.Dexterity}");
            Console.WriteLine($"Intelligence: {LevelAttributes.Intelligence}");
        }
    }
}
