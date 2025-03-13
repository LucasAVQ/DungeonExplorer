using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Program Class: Entry point for the game
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Dungeon Explorer!");
        Game game = new Game(); // Initialize the game
        game.Start(); // Start the game loop

        Console.WriteLine("Game Over. Thanks for playing!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(); // Wait for user input before closing
    }
}