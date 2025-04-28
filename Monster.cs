using System;
using DungeonExplorer;

// a basic monster that can attack player
public class Monster : Creature
{
    // constructor to set name and health
    public Monster(string name, int health) : base(name, health) { }

    // monster attacks a target creature
    public override void Attack(Creature target)
    {
        // if the monster is a dragon it deals more damage
        int damage = Name.ToLower().Contains("dragon") ? 20 : 10;
        Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
        target.TakeDamage(damage);
    }
}

