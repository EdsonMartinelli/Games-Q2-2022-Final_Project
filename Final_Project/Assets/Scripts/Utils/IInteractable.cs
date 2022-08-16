using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public enum InteractionType
    {
        NPC,
        Object,
        Machine,
        Trash
    }

    public InteractionType GetInteractionType();
}
