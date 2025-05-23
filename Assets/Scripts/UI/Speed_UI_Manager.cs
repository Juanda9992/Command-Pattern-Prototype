using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Speed_UI_Manager : MonoBehaviour
{
    [SerializeField] private Speed_Data[] speedValues;

    [SerializeField] private Button decreaseButton, increaseButton;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private int speedIndex = 1;

    void Start()
    {
        UpdateSpeedValue();

        decreaseButton.onClick.AddListener(DecreaseSpeed);
        increaseButton.onClick.AddListener(IncreaseSpeed);
    }

    private void DecreaseSpeed()
    {
        if (speedIndex - 1 >= 0)
        {
            speedIndex--;
            UpdateSpeedValue();
        }
        SetButtonsState();
    }

    private void IncreaseSpeed()
    {
        if (speedIndex + 1 < speedValues.Length)
        {
            speedIndex++;
            UpdateSpeedValue();
        }
        SetButtonsState();
    }

    private void UpdateSpeedValue()
    {
        Speed_Manager.instance._globalSpeed = speedValues[speedIndex].speedValue;
        speedText.text = speedValues[speedIndex].speedMultiplerText + $"<sub>x</sub>";
    }

    private void SetButtonsState()
    {
        decreaseButton.interactable = speedIndex > 0;
        increaseButton.interactable = speedIndex < speedValues.Length -1;
    }
}

[System.Serializable]
public class Speed_Data
{
    public float speedValue;
    public string speedMultiplerText;
}
