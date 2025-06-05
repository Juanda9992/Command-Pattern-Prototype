using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Gameflow_Manager : MonoBehaviour
{
    public static Custom_Gameflow_Manager instance;

    [SerializeField] private int goalNumber = -1;
    [SerializeField] private int counterNumber;

    void Awake()
    {
        instance = this;
    }
    public void SetWinCondition(Custom_Winning_Condition condition)
    {
        if (condition.winCondition == Custom_Winning_Condition.WinCondition.Counter)
        {
            counterNumber = 0;
            goalNumber = int.Parse(condition.parameters);
        }
    }

    public void IncreaseNumber()
    {
        Debug.Log("Increased");
        counterNumber++;
        CheckCounter();
    }

    public void DecreaseNumber()
    {
        counterNumber--;
        CheckCounter();
    }

    private void CheckCounter()
    {
        if (counterNumber == goalNumber)
        {
            Level_Loader_Manager.instance.ShowWinCanvas();
        }
    }
}
