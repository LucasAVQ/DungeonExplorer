using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;

namespace DungeonExplorer
{
    // Game Class: Handles the game flow, initializes the player and the dungeon rooms
    internal class Game
    {
        private Player player; // Player object
        private Dictionary<string, Room> rooms; // Stores rooms and their names
        private Room currentRoom; // Tracks the player's current room
        private static Random random = new Random(); // Random object for generating connections

        public Game()
        {
            // Get player's name
            Console.Write("Enter your character's name: ");
            string playerName;
            do
            {
                playerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(playerName))
                {
                    Console.Write("Name cannot be empty. Please enter a valid name: ");
                }
            } while (string.IsNullOrWhiteSpace(playerName));

            player = new Player(playerName, 100); // Player starts with 100 health
            InitializeRooms(); // Create rooms and connections

            // Ensure Entrance exists before setting currentRoom
            if (rooms.ContainsKey("Entrance"))
            {
                currentRoom = rooms["Entrance"];
            }
            else
            {
                Console.WriteLine("Error: 'Entrance' room was not initialized correctly.");
                currentRoom = rooms.Values.First(); // Defaults to the first available room
            }
        }

        // Initializes dungeon rooms and randomly connects them
        private void InitializeRooms()
        {
            List<string> roomNames = new List<string> { "Entrance", "Hallway", "Armory", "Library", "Treasure Room" };
            rooms = new Dictionary<string, Room>(); // // // // //

            // Create each room with a description
            foreach (var roomName in roomNames)
            {
                rooms[roomName] = new Room("You are in " + roomName + ".", new Dictionary<string, string>());
            }

            List<string> directions = new List<string> { "north", "south", "east", "west" };

            // Randomly connect rooms to each other
            foreach (var room in rooms.Values)
            {
                int numConnections = random.Next(1, 3); // Each room has 1-2 connections
                for (int i = 0; i < numConnections; i++)
                {
                    string direction = directions[random.Next(directions.Count)];
                    string randomRoom = roomNames[random.Next(roomNames.Count)];

                    if (randomRoom != room.GetDescription() && !room.CanMove(direction))
                    {
                        room.AddConnection(direction, randomRoom);
                        rooms[randomRoom].AddConnection(GetOppositeDirection(direction), room.GetDescription());
                    }
                }
            }
        }

        // Determines the opposite direction of movement
        private string GetOppositeDirection(string direction)
        {
            switch (direction)
            {
                case "north": return "south";
                case "south": return "north";
                case "east": return "west";
                case "west": return "east";
                default: return "";
            }
        }

        // Starts the game loop
        public void Start()
        {
            bool playing = true;
            Console.WriteLine("Welcome, " + player.Name + "! You find yourself in a mysterious dungeon.");

            while (playing)
            {
                // Display current room and available directions
                Console.WriteLine("\nCurrent Location: " + currentRoom.GetDescription());
                Console.WriteLine("Available directions: " + currentRoom.GetAvailableDirections());

                // Show menu options
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. Move to another room");
                Console.WriteLine("2. Check Player Status");
                Console.WriteLine("3. Pick Up an Item");
                Console.WriteLine("4. Exit Game");
                Console.Write("Enter your choice: ");

                string choice;
                do
                {
                    choice = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(choice))
                    {
                        Console.Write("Input cannot be empty. Please enter a valid choice: ");
                    }
                } while (string.IsNullOrWhiteSpace(choice));

                // Handle user input
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter direction (north/south/east/west): ");
                        string direction;
                        do
                        {
                            direction = Console.ReadLine().ToLower();
                            if (string.IsNullOrWhiteSpace(direction))
                            {
                                Console.Write("Direction cannot be empty. Please enter a valid direction: ");
                            }
                        } while (string.IsNullOrWhiteSpace(direction));

                        MoveToRoom(direction);
                        break;
                    case "2":
                        player.DisplayStatus();
                        break;
                    case "3":
                        Console.Write("Enter the name of the item: ");
                        string item;
                        do
                        {
                            item = Console.ReadLine();
                            if (string.IsNullOrWhiteSpace(item))
                            {
                                Console.Write("Item name cannot be empty. Please enter a valid item name: ");
                            }
                        } while (string.IsNullOrWhiteSpace(item));

                        player.PickUpItem(item);
                        break;
                    case "4":
                        playing = false;
                        Console.WriteLine("Exiting the dungeon... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Moves the player to another room if possible
        private void MoveToRoom(string direction)
        {
            string nextRoomName = currentRoom.GetNextRoom(direction);
            if (rooms.ContainsKey(nextRoomName))
            {
                currentRoom = rooms[nextRoomName];
                Console.WriteLine("\nYou move " + direction + " to " + currentRoom.GetDescription());
            }
            else
            {
                Console.WriteLine("\nThere's no room in that direction!");
            }
        }
    }
}

