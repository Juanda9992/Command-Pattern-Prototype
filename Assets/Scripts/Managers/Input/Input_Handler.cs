using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Handler : MonoBehaviour
{
    [SerializeField] private Player_Movement player_controller;
    public static Input_Handler Instance { get; private set; }

    public Command moveForward, rotateLeft, rotateRight, interact;
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
            rotateLeft.Execute();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rotateRight.Execute();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact.Execute();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveForward.Execute();
        }
    }

    public Player_Movement GetPlayer()
    {
        return player_controller;
    }

}
