using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCController : MonoBehaviour, INPC
{
    private Item.ItemType order;
    private bool isInService = false;
    private bool alreadyServed = false;
    [SerializeField] private DialogueObject NPCDialogue;
    [SerializeField] private DialogueObject NPCAfterServedFail;
    [SerializeField] private DialogueObject NPCAfterServedSuccess;
    [SerializeField] private DialogueObject NPCAlreadyServed;

    private void Awake()
    {
        int orderNumber = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Item.ItemType)).Length - 1);
        order = (Item.ItemType)orderNumber;
    }

    private void Start()
    {
        GameManager.GetGameManager().AddClient();
    }

    public void DialogueEnter(Inventory inventory)
    {
        if (alreadyServed)
        {
            DialogueUIManager.GetDialogueUIManager().ShowDialogue(NPCAlreadyServed.GetDialogue());
            return;
        }

        if (!isInService)
        {
            int lengthString = NPCDialogue.GetDialogue().Length;
            string[] newDialogue = new string[lengthString];
            Array.Copy(NPCDialogue.GetDialogue(), newDialogue, lengthString);
            newDialogue[lengthString - 1] += GetOrderItem();
            DialogueUIManager.GetDialogueUIManager().ShowDialogue(newDialogue);
            isInService = true;
            return;
        }

        Item item = inventory.GetItem();
        if (item != null)
        {
            if (item.GetItemType() == order)
            {
                DialogueUIManager.GetDialogueUIManager().ShowDialogue(NPCAfterServedSuccess.GetDialogue());
                MoneyUIManager.GetMoneyUIManager().updateMoney(10);
            }
            else
            {
                DialogueUIManager.GetDialogueUIManager().ShowDialogue(NPCAfterServedFail.GetDialogue());
                MoneyUIManager.GetMoneyUIManager().updateMoney(-10);
            }
        }
        else
        {
            DialogueUIManager.GetDialogueUIManager().ShowDialogue(NPCAfterServedFail.GetDialogue());
            MoneyUIManager.GetMoneyUIManager().updateMoney(-10);
        }
        alreadyServed = true;
        GameManager.GetGameManager().ClientWasServed();
    }

    public string GetOrderItem()
    {
        switch (order)
        {
            case Item.ItemType.Beer: return "uma cerveja?";
            case Item.ItemType.Coffee: return "um café?";
            case Item.ItemType.Food: return "o prato do dia?";
            case Item.ItemType.Juice: return "um suco?";
            case Item.ItemType.Lunch: return "um sanduíche?";
            case Item.ItemType.Water: return "um copo com água?";
            default: return "";
        }
    }

    public IInteractable.InteractionType GetInteractionType()
    {
        return IInteractable.InteractionType.NPC;
    }

}
