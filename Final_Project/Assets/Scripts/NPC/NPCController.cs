using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject NPCDialogue;

    public void InteractionEnter()
    {
        DialogueUISystem.GetDialogueUISystem().ShowDialogue(NPCDialogue);
    }

    public void InteractionExit()
    {
        
    }

    public InteractionType GetInteractionType()
    {
        return InteractionType.NPC;
    }

}
