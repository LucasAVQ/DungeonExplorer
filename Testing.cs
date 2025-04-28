using System;
using System.Diagnostics;
using DungeonExplorer;

namespace DungeonExplorer
{
    public static class Testing
    {
        public static void RunTests()
        {
            Console.WriteLine("Running test");

            // test creature damage
            Player testPlayer = new Player("Tester", 100);
            int initialHealth = testPlayer.Health;
            testPlayer.TakeDamage(10);
            Debug.Assert(testPlayer.Health == initialHealth - 10,
                "Player should lose 10 health after taking damage");

            // test room movement
            Room room1 = new Room("Room 1", "a plain room");
            Room room2 = new Room("Room 2", "a fancy room");
            room1.AddDirection("north", "Room 2");

            Debug.Assert(room1.CanMove("north") == true,
                "should be able to move north from Room 1");
            Debug.Assert(room1.GetNextRoom("north") == "Room 2",
                "moving north should lead to Room 2");

            // test inventory adding items
            Inventory inventory = new Inventory();
            Weapon sword = new Weapon("Sword", 10, 15);
            inventory.Add(sword);
            Debug.Assert(inventory.GetItemsOfType<Item>().Count == 1,
                "inventory should have 1 item after adding");

            // test using a potion
            testPlayer.Inventory.Add(new Potion("Healing Potion", 20));
            int healthBeforeUse = testPlayer.Health;
            var potions = testPlayer.Inventory.GetItemsOfType<Potion>();
            if (potions.Count > 0)
            {
                potions[0].Use(testPlayer);
            }
            Debug.Assert(testPlayer.Health > healthBeforeUse,
                "using a potion should increase health");

            Console.WriteLine("tests passed");
        }
    }
}

