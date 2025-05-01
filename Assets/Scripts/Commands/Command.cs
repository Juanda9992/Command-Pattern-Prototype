using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    public abstract void Execute();
}

public class MoveForwardCommand: Command
{
    public override void Execute()
    {
        Input_Handler.Instance.GetPlayer().MoveForward();
    }
}

public class RotateRightCommand: Command
{
    public override void Execute()
    {
        Input_Handler.Instance.GetPlayer().RotateRight();
    }
}

public class RotateLeftCommand: Command
{
    public override void Execute()
    {
        Input_Handler.Instance.GetPlayer().RotateLeft();
    }
}
public class InteractCommand: Command
{
    public override void Execute()
    {
        Input_Handler.Instance.GetPlayer().Interact();
    }
}