using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Action_Container_Button : MonoBehaviour
{
    [SerializeField]private int actionIndex;
    [SerializeField] private Image iconImage;
    [SerializeField] private Button actionButton;
    private ActionType thisAction;

    void Awake()
    {
        actionButton.onClick.AddListener(DeleteCommandFromList);   
    }
    public void SetActionType(ActionType actionType, int buttonIndex)
    {
        SetButtonIndex(buttonIndex);
        thisAction = actionType;
        SetButtonUI();
    }

    public void SetButtonIndex(int newIndex)
    {
        actionIndex = newIndex;
    }

    private void DeleteCommandFromList()
    {
        Debug.Log("Deleted " + actionIndex);
        Input_Handler.Instance.DeleteCommandAtPosition(actionIndex);

        Destroy(gameObject);
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
