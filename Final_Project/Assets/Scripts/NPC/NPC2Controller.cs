using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Controller : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueObject NPC2Dialogue;
    private bool isInInteract = false;
    private bool isFinished = true;

    public void InteractEnter()
    {
        isInInteract = true;
        isFinished = false;
        DialogueUISystem.GetDialogueUISystem().ShowDialogue(NPC2Dialogue);
    }

    public bool InteractExit()
    {
        return isFinished;
    }

    private void Update()
    {
        if (isInInteract)
        {
            isFinished = DialogueUISystem.GetDialogueUISystem().IsFinished();
        }
    }

}
