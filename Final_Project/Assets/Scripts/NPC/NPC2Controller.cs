using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Controller : MonoBehaviour, IInteractable
{

    private int numberOfInteraction = 0;

    public void InteractEnter()
    {
        numberOfInteraction++;
        print("NPC2 entrou em di�logo. Intera��es: " + (int) numberOfInteraction);
    }

    public void InteractExit()
    {
        print("NPC2 saiu do di�logo");
    }

}
