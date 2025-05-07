using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Action_Container_Button : MonoBehaviour
{
    private ActionType thisAction;

    public void SetActionType(ActionType actionType)
    {
        thisAction = actionType;
        SetButtonUI();
    }

    private void SetButtonUI()
    {
        TextMeshProUGUI buttonText = GetComponentInChildren<TextMeshProUGUI>();

        switch(thisAction)
        {
            case ActionType.RotateLeft:
                buttonText.text = "<=";
            break;

            case ActionType.RotateRight:
                buttonText.text = "=>";
            break;
            case ActionType.MoveForward:
                buttonText.text = "GO";
            break;

            case ActionType.Interact:
                buttonText.text = "E";
            break;
        }
    }
}
