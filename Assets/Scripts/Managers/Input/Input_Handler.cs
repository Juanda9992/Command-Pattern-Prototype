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
            allCommandsStored.Add(rotateLeft);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            allCommandsStored.Add(rotateRight);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            allCommandsStored.Add(interact);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            allCommandsStored.Add(moveForward);
        }
    }

    public Player_Movement GetPlayer()
    {
        return player_controller;
    }

    public void PlayStoredCommands()
    {
        
    }

}
