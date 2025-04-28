namespace DungeonExplorer
{
    // dragon is a type of monster
    public class Dragon : Monster
    {
        public Dragon(string name, int health) : base(name, health) { }

        // dragon attacks by breathing fire
        public override void Attack(Creature target)
        {
            int damage = 15;
            System.Console.WriteLine($"{Name} breathes fire for {damage} damage!");
            target.TakeDamage(damage);
        }
    }
}
