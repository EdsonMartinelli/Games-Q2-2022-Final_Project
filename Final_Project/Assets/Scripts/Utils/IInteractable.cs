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
    public string GetInteractionType();
    public void InteractionEnter();
    public bool isInteractionCompleted();
}
