using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isStopwatchStarted = false;
    private bool gameWasFinished = false;
    private int numberOfClientsToServe = 0;

    [SerializeField] private GameObject finalScreen;
    [SerializeField] private TMP_Text globalMoneyText;

    private GameManager() { }

    public static GameManager GetGameManager()
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
            finalScreen.SetActive(false);
        }
    }

    public void AddClient()
    {
        numberOfClientsToServe++;
    }

    public void ClientWasServed()
    {
        numberOfClientsToServe--;
    }

    public void StartStopwatch()
    {
        isStopwatchStarted = true;
    }

    private void Update()
    {
        //print(Time.timeScale);
        if (isStopwatchStarted && !gameWasFinished)
        {
            float stopwatch= StopwatchUIManager.GetStopwatchUIManager().SetStopwatchTime(Time.deltaTime);
            if (stopwatch <= 0 || numberOfClientsToServe == 0)
            {
                GlobalStatusSystem.GetGlobalStatusSystem().updateGlobalMoney(MoneyUIManager.GetMoneyUIManager().GetMoney());
                GlobalStatusSystem.GetGlobalStatusSystem().updateGlobalMoney(-5); // saude do irmao
                GlobalStatusSystem.GetGlobalStatusSystem().updateGlobalMoney(-8); // lucro do Bullgard
                globalMoneyText.text = GlobalStatusSystem.GetGlobalStatusSystem().GetGlobalMoney().ToString();
                gameWasFinished = true;
                Time.timeScale = 0;
                finalScreen.SetActive(true);
            }

        }
    }

    public void ResetStage()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Phase1");
    }
}
