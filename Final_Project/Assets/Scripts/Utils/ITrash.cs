using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrash : IInteractable
{
    public bool RemoveItem(Inventory inventory);
}
