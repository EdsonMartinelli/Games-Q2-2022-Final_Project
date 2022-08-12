using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Controller : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject NPC2Dialogue;

    public void InteractionEnter()
    {
        DialogueUISystem.GetDialogueUISystem().ShowDialogue(NPC2Dialogue);
    }

    public void InteractionExit()
    {
       
    }

    public InteractionType GetInteractionType()
    {
        return InteractionType.NPC;
    }
}
