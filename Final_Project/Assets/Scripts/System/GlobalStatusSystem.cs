using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStatusSystem : MonoBehaviour
{
    private static GlobalStatusSystem instance;
    private int globalMoney;

    private GlobalStatusSystem() { }

    public static GlobalStatusSystem GetGlobalStatusSystem()
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
            globalMoney = 0;
        }
    }

    public void updateGlobalMoney(int money)
    {
        globalMoney += money;
    }

    public int GetGlobalMoney()
    {
        return globalMoney;
    }
}
