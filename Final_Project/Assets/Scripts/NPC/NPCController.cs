using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, INPC
{
    [SerializeField] private DialogueObject NPCDialogue;

    public void DialogueEnter()
    {
        DialogueUISystem.GetDialogueUISystem().ShowDialogue(NPCDialogue.GetDialogue());
    }

    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.NPC;
    }

}
