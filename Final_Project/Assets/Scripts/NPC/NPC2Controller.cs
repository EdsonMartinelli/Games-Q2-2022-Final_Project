using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Controller : MonoBehaviour, INPC
{
    [SerializeField] private DialogueObject NPC2Dialogue;

    public void DialogueEnter()
    {
        DialogueUIManager.GetDialogueUIManager().ShowDialogue(NPC2Dialogue.GetDialogue());
    }

    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.NPC;
    }
}
