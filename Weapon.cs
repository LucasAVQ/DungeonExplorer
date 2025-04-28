using System;

namespace DungeonExplorer
{
    // weapon item that can be equipped by the player
    public class Weapon : Item
    {
        private int minDamage;
        private int maxDamage;

        // constructor to set weapon name and damage range
        public Weapon(string name, int minDamage, int maxDamage) : base(name)
        {
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        // when used, the player equips the weapon
        public override void Use(Player player)
        {
            player.EquipWeapon(this);
        }

        // get a random damage value between min and max
        public int GetDamage()
        {
            return new Random().Next(minDamage, maxDamage + 1);
        }
    }
}


