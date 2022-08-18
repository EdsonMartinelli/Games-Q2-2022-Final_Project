using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StopwatchUIManager : MonoBehaviour
{
    private static StopwatchUIManager instance;
    private float stopwatch;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private float originalStopwatchTimer = 10f;

    private StopwatchUIManager() { }

    public static StopwatchUIManager GetStopwatchUIManager()
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
            stopwatch = originalStopwatchTimer;
            textLabel.text = ((int)stopwatch).ToString();
        }
    }

    public float SetStopwatchTime(float timePast)
    {
        if (stopwatch > 0)
        {
            stopwatch -= timePast;
        } else
        {
            stopwatch = 0;
        }

        updateStopwatch();

        return stopwatch;
    }

    private void updateStopwatch()
    {
        textLabel.text = ((int) stopwatch).ToString();
        if(stopwatch < 10)
        {
            textLabel.color = new Color(255f, 0f, 0f);
        }
    }
}
