using DungeonExplorer;

// base class for all items that can be picked up
public abstract class Item : ICollectible
{
    // name of the item
    public string Name { get; set; }

    // constructor to set the name
    protected Item(string name)
    {
        Name = name;
    }

    // every item must define what happens when it is used
    public abstract void Use(Player player);
}


