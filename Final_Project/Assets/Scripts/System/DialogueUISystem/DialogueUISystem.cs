using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public delegate void NotifyDialogue();
public sealed class DialogueUISystem : MonoBehaviour
{

    private static DialogueUISystem instance;
    public event NotifyDialogue DialogueCompleted;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject continueButton;

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

        /*As Coroutine s�o assincronas,
         * as linha seguintes a fun��o ir�o rodar mesmo que a coroutine
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
            continueButton.SetActive(false);
            textLabel.text = dialogue;
            yield return new WaitForSeconds(1);
            continueButton.SetActive(true);
            yield return new WaitUntil(() => InputControllerSystem.GetInstance().GetInteract());
        }

        CloseDialog();
    }

}
