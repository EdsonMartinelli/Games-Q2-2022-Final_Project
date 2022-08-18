using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionManager : MonoBehaviour
{
    [SerializeField] private DialogueObject IntroductionDialogue;

    private void Start()
    {
        DialogueUIManager.GetDialogueUIManager().DialogueCompleted += () => VerifyIfDialogueIsCompleted();
        DialogueUIManager.GetDialogueUIManager().ShowDialogue(IntroductionDialogue.GetDialogue());
    }

    private void VerifyIfDialogueIsCompleted()
    {
        SceneManager.LoadScene("Phase1");
    }

}
