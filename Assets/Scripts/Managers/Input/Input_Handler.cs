using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_Handler : MonoBehaviour
{
    public static Action<int> OnCommandListChanged;
    [SerializeField] private Player_Movement player_controller;
    [SerializeField] private Action_Buttons_UI_Manager action_Buttons_UI_Manager;
    public static Input_Handler Instance { get; private set; }

    public Command moveForward, rotateLeft, rotateRight, interact;
    public bool isUndoingCommand = false;

    public List<Command> allCommandsStored = new List<Command>();
    [SerializeField] private bool deleteOnUndo;

    [Header("UI Settings")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button redoButton;
    [SerializeField] private Button undoButton;


    private bool executingFirstCommand;

    private int commandIndex = -1;
    void Awake()
    {
        Instance = this;

        moveForward = new MoveForwardCommand();
        rotateLeft = new RotateLeftCommand();
        rotateRight = new RotateRightCommand();
        interact = new InteractCommand();

        playButton.onClick.AddListener(PlayStoredCommands);
        redoButton.onClick.AddListener(RedoCommand);
        undoButton.onClick.AddListener(UndoLastCommand);

        SetUndoButtonState();
        SetPlayButtonState();
        SetRedoButtonState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AddCommand(rotateLeft, ActionType.RotateLeft);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddCommand(rotateRight, ActionType.RotateRight);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddCommand(interact, ActionType.Interact);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddCommand(moveForward, ActionType.MoveForward);
        }
    }

    public void AddCommand(Command command, ActionType actionType)
    {
        allCommandsStored.Add(command);
        action_Buttons_UI_Manager.InstantiateButton(actionType);

        SetUndoButtonState();
        SetPlayButtonState();

        OnCommandListChanged?.Invoke(allCommandsStored.Count);
    }

    public Player_Movement GetPlayer()
    {
        return player_controller;
    }

    private void SetUndoButtonState()
    {
        undoButton.interactable = allCommandsStored.Count > 0 && commandIndex >= 0;
    }


    private void SetPlayButtonState()
    {
        playButton.interactable = allCommandsStored.Count > 0;
    }

    private void SetRedoButtonState()
    {
        redoButton.interactable = allCommandsStored.Count > 0 && commandIndex < allCommandsStored.Count - 1;
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

    public void RedoCommand()
    {
        StartCoroutine(nameof(MoveNextCommand));
    }

    private IEnumerator UndoLastCommandCoroutine()
    {
        isUndoingCommand = true;
        allCommandsStored[commandIndex].Undo();

        commandIndex--;
        if (deleteOnUndo)
        {
            allCommandsStored.RemoveAt(allCommandsStored.Count - 1);
            action_Buttons_UI_Manager.RemoveLastAction();
        }


        action_Buttons_UI_Manager.MoveHightlightToButton(commandIndex);
        yield return new WaitForSeconds(1.1f);
        SetUndoButtonState();
        SetPlayButtonState();
        SetRedoButtonState();
        OnCommandListChanged?.Invoke(allCommandsStored.Count);

        isUndoingCommand = false;
    }

    private IEnumerator MoveNextCommand()
    {
        redoButton.interactable = false;

        commandIndex++;
        allCommandsStored[commandIndex].Execute();
        action_Buttons_UI_Manager.MoveHightlightToButton(commandIndex);
        yield return new WaitForSeconds(1.1f);
        SetRedoButtonState();
        SetUndoButtonState();
    }

    private IEnumerator CommandsReplay()
    {
        commandIndex = commandIndex == -1 ? 0 : commandIndex;
        int startindex = deleteOnUndo ? 0 : commandIndex;
        for (int i = startindex; i < allCommandsStored.Count; i++)
        {
            if (commandIndex != -1 && executingFirstCommand)
            {
                executingFirstCommand = false;
                i++;
            }
            commandIndex = i;
            allCommandsStored[i].Execute();
            action_Buttons_UI_Manager.MoveHightlightToButton(i);
            yield return new WaitForSeconds(1.1f);
        }

        executingFirstCommand = true;
        player_controller.CheckForCompletion();
        SetUndoButtonState();
        SetRedoButtonState();
    }

    public void ResetToDefault()
    {
        executingFirstCommand = false;
        action_Buttons_UI_Manager.ResetToDefault();
        allCommandsStored.Clear();
        OnCommandListChanged?.Invoke(allCommandsStored.Count);
        commandIndex = -1;

        SetPlayButtonState();
        SetUndoButtonState();
        SetRedoButtonState();
    }

    public void DeleteCommandAtPosition(int index)
    {
        allCommandsStored.RemoveAt(index);

        action_Buttons_UI_Manager.RemoveActionAt(index);
        OnCommandListChanged?.Invoke(allCommandsStored.Count);
    }

    void OnEnable()
    {
        Level_Loader_Manager.OnRestartLevel += ResetToDefault;
    }

    void OnDisable()
    {
        Level_Loader_Manager.OnRestartLevel -= ResetToDefault;
    }

}
