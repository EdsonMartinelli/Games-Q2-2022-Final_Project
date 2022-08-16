using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerMachineController : MonoBehaviour, IMachine
{
    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.Machine;
    }

    public Item GetItem()
    {
        Item newItem = new Item(Item.ItemType.Cerveja);
        return newItem;
    }
}
