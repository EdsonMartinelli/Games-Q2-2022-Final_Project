using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public delegate void NotifyDialogue();
public sealed class DialogueUIManager : MonoBehaviour
{

    private static DialogueUIManager instance;
    public event NotifyDialogue DialogueCompleted;

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private GameObject continueButton;

    private DialogueUIManager() { }

    public static DialogueUIManager GetDialogueUIManager()
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
            dialogueBox.SetActive(false);
        }
    }

    public void ShowDialogue(string[] dialogue)
    {

        dialogueBox.SetActive(true);

        /*As Coroutine são assincronas,
         * as linha seguintes a função irão rodar mesmo que a coroutine
         * esteja em andamento.*/

        StartCoroutine(GetEachDialogue(dialogue));
    }

    public void CloseDialog()
    {
        dialogueBox.SetActive(false);
        DialogueCompleted?.Invoke();
        DialogueCompleted = null;
        textLabel.text = string.Empty;
    }

    private IEnumerator GetEachDialogue(string[] dialogue)
    {
        foreach (string phrase in dialogue)
        {
            continueButton.SetActive(false);
            textLabel.text = phrase;
            yield return new WaitForSeconds(1);
            continueButton.SetActive(true);
            yield return new WaitUntil(() => InputControllerSystem.GetInstance().GetInteract());
        }

        CloseDialog();
    }

}
