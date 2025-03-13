using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    // Player Class represents the player character in the game
    public class Player
    {
        public string Name { get; private set; } // Player's name
        public int Health { get; private set; } // Player's health
        private List<string> inventory = new List<string>(); // Inventory to store items

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // Allows the player to pick up an item
        public void PickUpItem(string item)
        {
            inventory.Add(item);
            Console.WriteLine("You picked up: " + item);
        }

        // Displays player's inventory
        public void DisplayStatus()
        {
            Console.WriteLine("Player: " + Name + " | Health: " + Health);
            Console.WriteLine("Inventory: " + (inventory.Count > 0 ? string.Join(", ", inventory) : "Empty"));
        }
    }
}