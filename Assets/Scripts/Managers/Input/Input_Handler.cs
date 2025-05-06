using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Handler : MonoBehaviour
{
    [SerializeField] private Player_Movement player_controller;
    public static Input_Handler Instance { get; private set; }

    public Command moveForward, rotateLeft, rotateRight, interact;

    public List<Command> allCommandsStored = new List<Command>();
    void Awake()
    {
        Instance = this;

        moveForward = new MoveForwardCommand();
        rotateLeft = new RotateLeftCommand();
        rotateRight = new RotateRightCommand();
        interact = new InteractCommand();
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
        allCommandsStored[allCommandsStored.Count -1].Undo();
        allCommandsStored.RemoveAt(allCommandsStored.Count -1);
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
