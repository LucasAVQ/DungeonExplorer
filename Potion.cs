using System;
using DungeonExplorer;

// potion item that heals the player
public class Potion : Item
{
    // how much health the potion restores
    public int HealAmount { get; set; }

    // constructor to set potion name and heal amount
    public Potion(string name, int healAmount) : base(name)
    {
        HealAmount = healAmount;
    }

    // when used, heal the player
    public override void Use(Player player)
    {
        player.Heal(HealAmount);
        Console.WriteLine($"You use {Name} and heal {HealAmount} HP. Current HP: {player.Health}");
    }
}

