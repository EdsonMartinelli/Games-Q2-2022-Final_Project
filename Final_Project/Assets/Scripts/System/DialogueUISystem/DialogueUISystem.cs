using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public delegate void Notify();
public sealed class DialogueUISystem : MonoBehaviour
{

    private static DialogueUISystem instance;
    public event Notify DialogueCompleted;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;

    private DialogueUISystem() { }

    public static DialogueUISystem GetDialogueUISystem()
    {
        return instance;
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        CloseDialog();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);

        /*As Coroutine são assincronas,
         * as linha seguintes a função irão rodar mesmo que a coroutine
         * esteja em andamento.*/

        StartCoroutine(GetEachDialogue(dialogueObject));
    }

    public void CloseDialog()
    {
        dialogueBox.SetActive(false);
        DialogueCompleted?.Invoke();
        textLabel.text = string.Empty;
    }

    private IEnumerator GetEachDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.GetDialogue())
        {
            textLabel.text = dialogue;
            yield return new WaitForSeconds(1);
            yield return new WaitUntil(() => InputControllerSystem.GetInstance().GetInteract());
        }

        CloseDialog();
    }

}
