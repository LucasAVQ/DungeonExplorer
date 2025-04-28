namespace DungeonExplorer
{
    // interface for items that can be collected
    public interface ICollectible
    {
        string Name { get; } // name of the collectible
        void Use(Player player); // what happens when player uses the item
    }
}

