namespace DungeonExplorer
{
    // interface for anything that can take damage
    public interface IDamageable
    {
        int Health { get; }
        void TakeDamage(int amount);
    }
}
