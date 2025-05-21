using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Action_Buttons_UI_Manager : MonoBehaviour
{
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private GameObject buttonsPrefab;

    [SerializeField] private List<GameObject> allButtonsStored;

    [SerializeField] private GameObject highlightButton;

    public void InstantiateButton(ActionType actionType)
    {
        GameObject currentButton = Instantiate(buttonsPrefab, buttonsParent);
        currentButton.SetActive(true);
        currentButton.GetComponent<Action_Container_Button>().SetActionType(actionType);

        allButtonsStored.Add(currentButton);
    }

    public void RemoveLastAction()
    {
        Destroy(allButtonsStored[allButtonsStored.Count - 1]);
        allButtonsStored.RemoveAt(allButtonsStored.Count - 1);

        MoveHightlightToButton(allButtonsStored.Count - 1);
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
