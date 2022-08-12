using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionType
{
    NPC,
    Object,
    Item
}

public interface IInteractable
{
    public InteractionType GetInteractionType();
    public void InteractionEnter();
    public void InteractionExit();
}
