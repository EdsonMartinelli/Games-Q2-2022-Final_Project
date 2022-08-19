using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour, ITrash
{
    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.Trash;
    }

    public bool RemoveItem(Inventory inventory)
    {
        Item removedItem = inventory.GetItem();

        if(removedItem == null)
        {
            return false;
        }

        MoneyUIManager.GetMoneyUIManager().updateMoney(-10);
        return true;
    }
}
