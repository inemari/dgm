using DungeonMaster.Enums;

namespace DungeonMaster.Items
{
    /// <summary>
    /// Represents a weapon that can be equipped by heroes.
    /// </summary>
    public class Weapon : Item
    {
        // Gets or sets the type of the weapon (e.g., sword, dagger, etc.).
        public WeaponType WeaponType { get; set; }

        // Gets or sets the damage dealt by the weapon.
        public int WeaponDamage { get; set; }

        // Constructor initializing a weapon with its details.
        public Weapon(string name, int requiredLevel, WeaponType weaponType, int weaponDamage)
            : base(name, requiredLevel, Slot.Weapon)
        {
            WeaponType = weaponType;
            WeaponDamage = weaponDamage;
        }
    }
}
