using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject NPCDialogue;
    private bool isInInteract = false;
    private bool isFinished = true;

    public void InteractEnter()
    {
        isInInteract = true;
        isFinished = false;
        DialogueUISystem.GetDialogueUISystem().ShowDialogue(NPCDialogue);
    }

    public bool InteractExit()
    {
        return isFinished;
    }

    private void Update()
    {
        if ( isInInteract)
        {
            isFinished = DialogueUISystem.GetDialogueUISystem().IsFinished();
        }
    }
}
