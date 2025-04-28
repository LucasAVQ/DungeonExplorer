using System.Collections.Generic;
using DungeonExplorer;

public class GameMap
{
    private Dictionary<string, Room> rooms = new Dictionary<string, Room>();

    public GameMap()
    {
        InitializeRooms();
    }

    public Room GetRoom(string name)
    {
        return rooms.ContainsKey(name) ? rooms[name] : null;
    }

    private void ConnectRooms(Room fromRoom, string fromDirection, Room toRoom, string toDirection)
    {
        fromRoom.AddDirection(fromDirection, toRoom.Name);
        toRoom.AddDirection(toDirection, fromRoom.Name);
    }

    private void InitializeRooms()
    {
        var entrance = new Room("Entrance", "A dark, musty entrance to the dungeon.");
        var hall = new Room("Hall", "A long stone hallway with torches.");
        var treasure = new Room("Treasure Room", "A room glittering with gold and danger.");
        var armoury = new Room("Armoury", "An old armoury filled with rusty weapons and broken shields.");
        var library = new Room("Library", "A dusty library filled with ancient tomes and forgotten knowledge.");

        // Connect rooms using two-way connections
        ConnectRooms(entrance, "north", hall, "south");
        ConnectRooms(hall, "east", treasure, "west");
        ConnectRooms(hall, "west", armoury, "east");
        ConnectRooms(hall, "north", library, "south");

        // Place items
        entrance.Items.Add(new Potion("Small Potion", 20));
        hall.Items.Add(new Weapon("Rusty Sword", 7, 10));
        treasure.Items.Add(new Potion("Elixir", 50));
        armoury.Items.Add(new Weapon("Battle Axe", 10, 15));
        library.Items.Add(new Potion("Ancient Healing Scroll", 30));

        // Place monsters
        hall.Monsters.Add(new Monster("Goblin", 30));
        treasure.Monsters.Add(new Monster("Dragon", 100));
        armoury.Monsters.Add(new Monster("Armoured Skeleton", 40));
        library.Monsters.Add(new Monster("Ghost", 25));

        // Add rooms to the map
        rooms["Entrance"] = entrance;
        rooms["Hall"] = hall;
        rooms["Treasure Room"] = treasure;
        rooms["Armoury"] = armoury;
        rooms["Library"] = library;
    }
}

