using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject NPCDialogue;
    private bool isFinished = true;

    public void InteractEnter()
    {
        isFinished = false;
        DialogueUISystem.GetDialogueUISystem().ShowDialogue(NPCDialogue);
        DialogueUISystem.GetDialogueUISystem().DialogueCompleted += () => whenCompleted();
    }

    private void whenCompleted()
    {
        this.isFinished = true;
        DialogueUISystem.GetDialogueUISystem().DialogueCompleted -= () => whenCompleted();
    }

    public bool InteractExit()
    {
        return isFinished;
    }

}
