using System.Collections;
using System.Collections.Generic;

public class Item
{
    public enum ItemType
    {
        Beer,
        Coffee,
        Food,
        Juice,
        Water,
        Lunch
    }

    private ItemType type;

    public Item (ItemType type)
    {
        this.type = type;
    }
    public ItemType GetItemType()
    {
        return type;
    }
}
