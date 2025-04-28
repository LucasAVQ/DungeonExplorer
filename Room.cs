using System;
using System.Collections.Generic;
using System.Linq;

// represents a room in the dungeon
public class Room
{
    public string Name { get; set; } // name of the room
    public string Description { get; set; } // description of the room
    public List<Monster> Monsters { get; set; } = new List<Monster>(); // monsters in the room
    public List<Item> Items { get; set; } = new List<Item>(); // items in the room
    public Dictionary<string, string> Directions { get; set; } = new Dictionary<string, string>(); // directions to other rooms

    // constructor to set name and description
    public Room(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // add a direction leading to another room
    public void AddDirection(string direction, string roomName)
    {
        Directions[direction] = roomName;
    }

    // get the room name in the given direction
    public string GetNextRoom(string direction)
    {
        return Directions.ContainsKey(direction) ? Directions[direction] : null;
    }

    // check if moving in a direction is possible
    public bool CanMove(string direction)
    {
        return Directions.ContainsKey(direction);
    }

    // find the monster in the room with the most health
    public Monster GetStrongestMonster()
    {
        return Monsters.OrderByDescending(m => m.Health).FirstOrDefault();
    }
}

