using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool isStopwatchStarted = false;

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
        }
    }

    public void StartStopwatch()
    {
        isStopwatchStarted = true;
    }

    private void Update()
    {
        if (isStopwatchStarted)
        {
            float stopwatch= StopwatchUIManager.GetStopwatchUIManager().SetStopwatchTime(Time.deltaTime);
            if (stopwatch <= 0)
            {
                print("acabou o game");
            }

        }
    }
}
