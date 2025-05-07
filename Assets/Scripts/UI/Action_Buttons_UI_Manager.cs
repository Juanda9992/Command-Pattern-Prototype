using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Buttons_UI_Manager : MonoBehaviour
{
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private GameObject buttonsPrefab;

    public void InstantiateButton(ActionType actionType)
    {
        GameObject currentButton = Instantiate(buttonsPrefab,buttonsParent);
        currentButton.SetActive(true);
        currentButton.GetComponent<Action_Container_Button>().SetActionType(actionType);
    }
}
