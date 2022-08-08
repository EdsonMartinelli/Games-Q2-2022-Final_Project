using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Controller : MonoBehaviour, IInteractable
{

    [SerializeField] private DialogueObject NPC2Dialogue;
    private bool isFinished = true;

    public void InteractEnter()
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

    public bool InteractExit()
    {
        return isFinished;
    }

}
