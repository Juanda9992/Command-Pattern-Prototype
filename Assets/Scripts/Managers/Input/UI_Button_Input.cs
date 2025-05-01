using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button_Input : MonoBehaviour
{
    [SerializeField] private ActionType buttonAction;

    private Button actionButton;

    void Awake()
    {
        actionButton = GetComponent<Button>();

        actionButton.onClick.AddListener(ExecuteAction);
    }

    private void ExecuteAction()
    {
        switch(buttonAction)
        {
            case ActionType.RotateLeft:
                Input_Handler.Instance.rotateLeft.Execute();
            break;
            case ActionType.RotateRight:
                Input_Handler.Instance.rotateRight.Execute();
            break;
            case ActionType.MoveForward:
                Input_Handler.Instance.moveForward.Execute();
            break;
            case ActionType.Interact:
                Input_Handler.Instance.interact.Execute();
            break;
        }
    }
}

public enum ActionType
{
    RotateLeft,
    RotateRight,
    MoveForward,
    Interact
}
