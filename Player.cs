using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // the player that the user controls
    public class Player : Creature
    {
        // player inventory of items
        public Inventory Inventory { get; private set; }

        // currently equipped weapon
        private Weapon equippedWeapon;

        // constructor to set player name and health
        public Player(string name, int health) : base(name, health)
        {
            Inventory = new Inventory();
        }

        // pick up an item and add it to the inventory
        public void PickUpItem(Item item)
        {
            Inventory.Add(item);
            Console.WriteLine("You picked up: " + item.Name);
        }

        // use an item by its name
        public void UseItem(string itemName)
        {
            Item item = Inventory.FindItemByName(itemName);
            if (item != null)
            {
                item.Use(this);
                Inventory.Remove(item);
            }
            else
            {
                Console.WriteLine("You don't have that item.");
            }
        }

        // equip a weapon
        public void EquipWeapon(Weapon weapon)
        {
            equippedWeapon = weapon;
            Console.WriteLine("You equipped: " + weapon.Name);
        }

        // attack a target creature
        public override void Attack(Creature target)
        {
            // damage depends on if a weapon is equipped
            int damage = equippedWeapon != null ? equippedWeapon.GetDamage() : 2;
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.TakeDamage(damage);
        }

        // show the player's current status
        public void DisplayStatus()
        {
            Console.WriteLine($"Player: {Name} | Health: {Health}");
            Console.WriteLine($"Equipped Weapon: {(equippedWeapon != null ? equippedWeapon.Name : "None")}");
            Inventory.ListItems();
        }
    }
}

