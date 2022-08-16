using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    private Queue<Item> inventory;
    public Inventory ()
    {
        inventory = new Queue<Item>();
    }

    public bool AddItem(Item item)
    {
        if(inventory.Count >= 3)
        {
            return false;
        }

        inventory.Enqueue(item);
        return true;
    }

    public Item GetItem()
    {
        return inventory.Dequeue();
    }
}
