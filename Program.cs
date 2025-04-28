using DungeonExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// entry point for the game
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Dungeon Explorer!");
        Game game = new Game(); // initialize the game
        game.Start(); // start the game loop

        Console.WriteLine("Game Over. Thanks for playing!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(); // wait for user input before closing
    }
}