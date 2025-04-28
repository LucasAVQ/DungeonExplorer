namespace DungeonExplorer
{
    // goblin is a type of monster
    public class Goblin : Monster
    {
        public Goblin(string name, int health) : base(name, health) { }

        // goblin attacks by stabbing
        public override void Attack(Creature target)
        {
            int damage = 5;
            System.Console.WriteLine($"{Name} stabs you with a knife for {damage} damage!");
            target.TakeDamage(damage);
        }
    }
}
