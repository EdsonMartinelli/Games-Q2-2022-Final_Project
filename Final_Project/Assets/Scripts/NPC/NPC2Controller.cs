using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Controller : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueObject NPC2Dialogue;
    private bool isFinished = true;

    public void InteractionEnter()
    {
        isFinished = false;
        DialogueUISystem.GetDialogueUISystem().ShowDialogue(NPC2Dialogue);
        DialogueUISystem.GetDialogueUISystem().DialogueCompleted += () => whenCompleted();
    }

    private void whenCompleted()
    {
        this.isFinished = true;
        DialogueUISystem.GetDialogueUISystem().DialogueCompleted -= () => whenCompleted();
    }

    public bool isInteractionCompleted()
    {
        return isFinished;
    }

    public string GetInteractionType()
    {
        return InteractionType.NPC.ToString();
    }
}
