using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, IInteractable
{

    private int numberOfInteraction = 0;

    public void InteractEnter()
    {

        numberOfInteraction++;
        print("NPC1 entrou em diálogo. Interações: " + (int)numberOfInteraction);
    }

    public void InteractExit()
    {
        print("NPC1 saiu do diálogo");
    }
}
