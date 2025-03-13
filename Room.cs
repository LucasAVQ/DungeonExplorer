using System.Collections.Generic;

namespace DungeonExplorer
{
    // Room Class represents a room in the dungeon
    public class Room
    {
        private string description; // Room description
        private Dictionary<string, string> connections; // Stores available room connections

        public Room(string description, Dictionary<string, string> connections)
        {
            this.description = description;
            this.connections = connections;
        }

        // Return room description
        public string GetDescription()
        {
            return description;
        }

        // Adds connection between rooms
        public void AddConnection(string direction, string roomName)
        {
            connections[direction] = roomName;
        }

        // Checks if the player can move in a given direction
        public bool CanMove(string direction)
        {
            return connections.ContainsKey(direction);
        }

        // Retrieves the next room in a given direction
        public string GetNextRoom(string direction)
        {
            return connections.ContainsKey(direction) ? connections[direction] : null;
        }

        // Returns movement options
        public string GetAvailableDirections()
        {
            return connections.Count > 0 ? string.Join(", ", connections.Keys) : "None";
        }
    }
}
