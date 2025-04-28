using System;

namespace DungeonExplorer
{
    // base class for anything that can fight (player, monster)
    public abstract class Creature : IDamageable
    {
        // creature name
        public string Name { get; protected set; }

        // creature health
        public int Health { get; protected set; }

        // constructor to set name and health
        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        // take damage and reduce health
        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }

        // heal and increase health
        public virtual void Heal(int amount)
        {
            Health += amount;
        }

        // every creature must define how it attacks
        public abstract void Attack(Creature target);
    }
}


