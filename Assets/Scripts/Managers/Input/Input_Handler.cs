using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_Handler : MonoBehaviour
{
    [SerializeField] private Player_Movement player_controller;
    [SerializeField] private Action_Buttons_UI_Manager action_Buttons_UI_Manager;
    public static Input_Handler Instance { get; private set; }

    public Command moveForward, rotateLeft, rotateRight, interact;
    public bool isUndoingCommand = false;

    public List<Command> allCommandsStored = new List<Command>();

    [Header("UI Settings")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button undoButton;
    void Awake()
    {
        Instance = this;

        moveForward = new MoveForwardCommand();
        rotateLeft = new RotateLeftCommand();
        rotateRight = new RotateRightCommand();
        interact = new InteractCommand();

        playButton.onClick.AddListener(PlayStoredCommands);
        undoButton.onClick.AddListener(UndoLastCommand);

        SetUndoButtonState();
        SetPlayButtonState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AddCommand(rotateLeft,ActionType.RotateLeft);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddCommand(rotateRight,ActionType.RotateRight);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddCommand(interact,ActionType.Interact);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddCommand(moveForward,ActionType.MoveForward);
        }
    }

    public void AddCommand(Command command, ActionType actionType)
    {
        allCommandsStored.Add(command);
        action_Buttons_UI_Manager.InstantiateButton(actionType);

        SetUndoButtonState();
        SetPlayButtonState();
    }

    public Player_Movement GetPlayer()
    {
        return player_controller;
    }

    private void SetUndoButtonState()
    {
        undoButton.interactable = allCommandsStored.Count > 0;
    }


    private void SetPlayButtonState()
    {
        playButton.interactable = allCommandsStored.Count >0;
    }

    [ContextMenu("Test Replay")]
    public void PlayStoredCommands()
    {
        StartCoroutine(nameof(CommandsReplay));
    }

    [ContextMenu("Undo Command")]
    public void UndoLastCommand()
    {
        StartCoroutine(nameof(UndoLastCommandCoroutine));
    }

    private IEnumerator UndoLastCommandCoroutine()
    {
        isUndoingCommand = true;
        allCommandsStored[allCommandsStored.Count -1].Undo();
        allCommandsStored.RemoveAt(allCommandsStored.Count -1);

        SetUndoButtonState();
        SetPlayButtonState();

        action_Buttons_UI_Manager.RemoveLastAction();

        yield return new WaitForSeconds(1.1f);

        isUndoingCommand = false;
    }

    private IEnumerator CommandsReplay()
    {
        for(int i = 0; i< allCommandsStored.Count;i++)
        {
            allCommandsStored[i].Execute();
            action_Buttons_UI_Manager.MoveHightlightToButton(i);
            yield return new WaitForSeconds(1.1f);
        }
    }

}
