using System;
using DungeonExplorer;

// the main game class that controls the game flow
public class Game
{
    private Player player; // the player character
    private Room currentRoom; // the room the player is currently in
    private GameMap gameMap; // the map of all rooms

    // start the game
    public void Start()
    {
        // create the player
        player = new Player("Hero", 100);

        // create the game map
        gameMap = new GameMap();

        // set starting room
        currentRoom = gameMap.GetRoom("Entrance");

        Console.WriteLine("Welcome to the Dungeon Explorer!");

        // main game loop
        while (true)
        {
            // show current room name and description
            Console.WriteLine($"\nCurrent Room: {currentRoom.Name}");
            Console.WriteLine(currentRoom.Description);

            // show available directions to move
            Console.WriteLine("Available directions:");
            foreach (var direction in currentRoom.Directions.Keys)
            {
                Console.WriteLine("- " + direction);
            }

            // show items in the room
            if (currentRoom.Items.Count > 0)
            {
                Console.WriteLine("You see the following items:");
                foreach (var item in currentRoom.Items)
                    Console.WriteLine("- " + item.Name);
            }

            // show monsters in the room
            if (currentRoom.Monsters.Count > 0)
            {
                Console.WriteLine("Enemies here:");
                foreach (var monster in currentRoom.Monsters)
                    Console.WriteLine($"- {monster.Name} (HP: {monster.Health})");
            }

            // ask player what to do next
            Console.WriteLine("Choose an action: move, pickup, inventory, use, attack, quit");
            string action = Console.ReadLine()?.ToLower();

            switch (action)
            {
                case "move":
                    // move to another room
                    Console.WriteLine("Which direction?");
                    string dir = Console.ReadLine()?.ToLower();
                    if (string.IsNullOrWhiteSpace(dir) || !currentRoom.CanMove(dir))
                    {
                        Console.WriteLine("Invalid direction.");
                    }
                    else
                    {
                        Move(dir);
                    }
                    break;

                case "pickup":
                    // pick up an item from the room
                    if (currentRoom.Items.Count == 0)
                    {
                        Console.WriteLine("There are no items to pick up.");
                        break;
                    }

                    Console.WriteLine("Which item?");
                    string itemName = Console.ReadLine();
                    var item = currentRoom.Items.Find(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
                    if (item != null)
                    {
                        player.Inventory.Add(item);
                        currentRoom.Items.Remove(item);
                        Console.WriteLine("Picked up " + item.Name);
                    }
                    else
                    {
                        Console.WriteLine("Item not found.");
                    }
                    break;

                case "inventory":
                    // Show the player's inventory
                    player.Inventory.ListItems();
                    break;

                case "use":
                    // use an item from the inventory
                    Console.WriteLine("Enter item name to use:");
                    string useName = Console.ReadLine();
                    var foundItem = player.Inventory.FindItemByName(useName);

                    if (foundItem == null)
                    {
                        Console.WriteLine("Item not found in inventory.");
                        break;
                    }

                    try
                    {
                        foundItem.Use(player);
                        player.Inventory.Remove(foundItem);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error using item: " + ex.Message);
                    }
                    break;

                case "attack":
                    // attack a monster in the room
                    if (currentRoom.Monsters.Count == 0)
                    {
                        Console.WriteLine("No monsters here.");
                        break;
                    }

                    Console.WriteLine("Who do you want to attack?");
                    string targetName = Console.ReadLine();
                    Monster target = currentRoom.Monsters.Find(m => m.Name.Equals(targetName, StringComparison.OrdinalIgnoreCase));

                    if (target == null)
                    {
                        Console.WriteLine("Monster not found.");
                        break;
                    }

                    player.Attack(target);

                    if (target.Health <= 0)
                    {
                        Console.WriteLine($"{target.Name} defeated!");
                        currentRoom.Monsters.Remove(target);
                    }
                    else
                    {
                        // monster attacks back if not defeated
                        target.Attack(player);
                        if (player.Health <= 0)
                        {
                            Console.WriteLine("You have died. Game over.");
                            return;
                        }
                    }
                    break;

                case "quit":
                    // end the game
                    Console.WriteLine("Thanks for playing!");
                    return;

                default:
                    // handle wrong commands
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }

    // move to a different room in the specified direction
    private void Move(string direction)
    {
        string nextRoomName = currentRoom.GetNextRoom(direction);
        Room nextRoom = gameMap.GetRoom(nextRoomName);

        if (nextRoom != null)
        {
            currentRoom = nextRoom;
            Console.WriteLine("You enter: " + currentRoom.Name);
        }
        else
        {
            Console.WriteLine("You can't go that way.");
        }
    }
}



