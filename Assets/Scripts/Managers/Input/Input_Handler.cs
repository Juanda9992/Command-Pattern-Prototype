using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_Handler : MonoBehaviour
{
    [SerializeField] private Player_Movement player_controller;
    public static Input_Handler Instance { get; private set; }

    public Command moveForward, rotateLeft, rotateRight, interact;
    public bool isUndoingCommand = false;

    public List<Command> allCommandsStored = new List<Command>();

    [Header("UI Settings")]
    [SerializeField] private Button playButton, undoButton;
    void Awake()
    {
        Instance = this;

        moveForward = new MoveForwardCommand();
        rotateLeft = new RotateLeftCommand();
        rotateRight = new RotateRightCommand();
        interact = new InteractCommand();

        playButton.onClick.AddListener(PlayStoredCommands);
        undoButton.onClick.AddListener(UndoLastCommand);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AddCommand(rotateLeft);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            AddCommand(rotateRight);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            AddCommand(interact);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            AddCommand(moveForward);
        }
    }

    public void AddCommand(Command command)
    {
        Debug.Log(command);
        allCommandsStored.Add(command);
    }

    public Player_Movement GetPlayer()
    {
        return player_controller;
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

        yield return new WaitForSeconds(1.1f);

        isUndoingCommand = false;
    }

    private IEnumerator CommandsReplay()
    {
        for(int i = 0; i< allCommandsStored.Count;i++)
        {
            allCommandsStored[i].Execute();
            yield return new WaitForSeconds(1.1f);
        }
    }

}
