using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Buttons_UI_Manager : MonoBehaviour
{
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private GameObject buttonsPrefab;

    [SerializeField] private List<GameObject> allButtonsStored;

    public void InstantiateButton(ActionType actionType)
    {
        GameObject currentButton = Instantiate(buttonsPrefab,buttonsParent);
        currentButton.SetActive(true);
        currentButton.GetComponent<Action_Container_Button>().SetActionType(actionType);

        allButtonsStored.Add(currentButton);
    }

    public void RemoveLastAction()
    {
        Destroy(allButtonsStored[allButtonsStored.Count-1]);
        allButtonsStored.RemoveAt(allButtonsStored.Count-1);
    }
}
