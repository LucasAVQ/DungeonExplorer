using System;
using System.Collections.Generic;
using System.Linq;

// manages the player's items
public class Inventory
{
    // list to store items
    private List<Item> items = new List<Item>();

    // add an item to the inventory
    public void Add(Item item)
    {
        if (item != null) items.Add(item);
    }

    // remove an item from the inventory
    public void Remove(Item item)
    {
        if (item != null) items.Remove(item);
    }

    // show all items in the inventory
    public void ListItems()
    {
        if (!items.Any())
        {
            Console.WriteLine("Your inventory is empty.");
            return;
        }

        foreach (var item in items)
        {
            Console.WriteLine(item.Name);
        }
    }

    // find an item by its name
    public Item FindItemByName(string name)
    {
        return items.FirstOrDefault(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    // get all items of a specific type
    public List<T> GetItemsOfType<T>() where T : Item
    {
        return items.Where(item => item is T).Cast<T>().ToList();
    }
}


