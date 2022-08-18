using System.Collections;
using System.Collections.Generic;

public class Inventory
{
    private Queue<Item> inventory;
    private int size;

    public Inventory(int size)
    {
        inventory = new Queue<Item>();
        this.size = size;
    }

    public bool AddItem(Item item)
    {
        if(inventory.Count >= size)
        {
            return false;
        }

        inventory.Enqueue(item);
        InventoryUIManager.GetInvetoryUIManager().UpdateInventory(this);
        return true;
    }

    public Item GetItem()
    {
        if(inventory.Count > 0)
        {
            Item item = inventory.Dequeue();
            InventoryUIManager.GetInvetoryUIManager().UpdateInventory(this);
            return item;
        }
        return null;
    }

    public Queue<Item> GetQueue()
    {
        return inventory;
    }
}
