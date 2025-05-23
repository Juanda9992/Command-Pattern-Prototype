using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Action_Buttons_UI_Manager : MonoBehaviour
{
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private GameObject buttonsPrefab;

    [SerializeField] private List<GameObject> allButtonsStored;

    [SerializeField] private GameObject highlightButton;

    [SerializeField] private TextMeshProUGUI blocksText;

    void Start()
    {
        SetBlockText();
    }

    private void SetBlockText()
    {
        blocksText.text = allButtonsStored.Count + "/" + Level_Rules_Manager.GetActiveLevelRules().maxBlockLimit;
    }
    public void InstantiateButton(ActionType actionType)
    {
        GameObject currentButton = Instantiate(buttonsPrefab, buttonsParent);
        currentButton.SetActive(true);
        currentButton.GetComponent<Action_Container_Button>().SetActionType(actionType, allButtonsStored.Count);

        allButtonsStored.Add(currentButton);
        SetBlockText();
    }

    public void RemoveLastAction()
    {
        Destroy(allButtonsStored[allButtonsStored.Count - 1]);
        allButtonsStored.RemoveAt(allButtonsStored.Count - 1);

        MoveHightlightToButton(allButtonsStored.Count - 1);
        SetBlockText();
    }

    public void RemoveActionAt(int index)
    {
        allButtonsStored.RemoveAt(index);
        RecalculateButtonsIndex();
        SetBlockText();
    }

    private void RecalculateButtonsIndex()
    {
        for (int i = 0; i < allButtonsStored.Count; i++)
        {
            allButtonsStored[i].GetComponent<Action_Container_Button>().SetButtonIndex(i);
        }

    }

    public void MoveHightlightToButton(int index)
    {
        if (index >= 0)
        {
            highlightButton.SetActive(true);

            highlightButton.transform.position = allButtonsStored[index].transform.position;
        }
        else
        {
            highlightButton.SetActive(false);
        }
    }

    public void ResetToDefault()
    {
        for (int i = 0; i < allButtonsStored.Count; i++)
        {
            Destroy(allButtonsStored[i]);
        }
        allButtonsStored.Clear();
        highlightButton.SetActive(false);
    }
}
