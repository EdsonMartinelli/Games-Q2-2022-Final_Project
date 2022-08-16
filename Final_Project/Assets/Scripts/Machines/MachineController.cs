using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : MonoBehaviour, IMachine
{
    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.Machine;
    }

    public void GetItem()
    {
        print("da o item");
    }
}
