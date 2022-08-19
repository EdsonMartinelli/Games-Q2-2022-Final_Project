using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyUIManager : MonoBehaviour
{
    private static MoneyUIManager instance;
    private int amountOfMoney;

    [SerializeField] private TMP_Text textLabel;


    private MoneyUIManager() { }

    public static MoneyUIManager GetMoneyUIManager()
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
            amountOfMoney = 0;
        }
    }

    public void updateMoney(int money)
    {
        amountOfMoney += money;
        textLabel.text = amountOfMoney.ToString();
    }

    public int GetMoney()
    {
        return amountOfMoney;
    }


}
