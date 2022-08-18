using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMachineController : MonoBehaviour, IMachine
{
    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.Machine;
    }

    public Item GetItem()
    {
        Item newItem = new Item(Item.ItemType.Water);
        return newItem;
    }
}
