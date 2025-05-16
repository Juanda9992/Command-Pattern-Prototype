using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Action_Container_Button : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    private ActionType thisAction;

    public void SetActionType(ActionType actionType)
    {
        thisAction = actionType;
        SetButtonUI();
    }

    private void SetButtonUI()
    {
        switch (thisAction)
        {
            case ActionType.RotateLeft:
                iconImage.sprite = Asset_Database_Manager.instance.GetButtonSprite(0);
                break;

            case ActionType.RotateRight:
                iconImage.sprite = Asset_Database_Manager.instance.GetButtonSprite(1);
                break;
            case ActionType.MoveForward:
                iconImage.sprite = Asset_Database_Manager.instance.GetButtonSprite(2);
                break;

            case ActionType.Interact:
                iconImage.sprite = Asset_Database_Manager.instance.GetButtonSprite(3);
                break;
        }
        
    }
}
