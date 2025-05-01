using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Handler : MonoBehaviour
{
    [SerializeField] private Player_Movement player_controller;
    public static Input_Handler Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            player_controller.RotateLeft();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            player_controller.RotateRight();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            player_controller.Interact();
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            player_controller.MoveForward();
        }
    }

    public Player_Movement GetPlayer()
    {
        return player_controller;
    }

}
