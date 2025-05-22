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

    private void SetButtonState(int elementsInCommandList)
    {
        if (Level_Rules_Manager.GetActiveLevelRules().maxBlockLimit > 0)
        {
            actionButton.interactable = Level_Rules_Manager.GetActiveLevelRules().maxBlockLimit > elementsInCommandList;
        }
    }

    private void ExecuteAction()
    {
        switch (buttonAction)
        {
            case ActionType.RotateLeft:
                Input_Handler.Instance.AddCommand(new RotateLeftCommand(), ActionType.RotateLeft);
                break;
            case ActionType.RotateRight:
                Input_Handler.Instance.AddCommand(new RotateRightCommand(), ActionType.RotateRight);
                break;
            case ActionType.MoveForward:
                Input_Handler.Instance.AddCommand(new MoveForwardCommand(), ActionType.MoveForward);
                break;
            case ActionType.Interact:
                Input_Handler.Instance.AddCommand(new InteractCommand(), ActionType.Interact);
                break;
        }
    }

    void OnEnable()
    {
        Input_Handler.OnCommandListChanged += SetButtonState;
    }

    void OnDisable()
    {
        Input_Handler.OnCommandListChanged -= SetButtonState;
    }
}

public enum ActionType
{
    RotateLeft,
    RotateRight,
    MoveForward,
    Interact
}
