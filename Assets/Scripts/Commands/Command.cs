using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command 
{
    public abstract void Execute();
    public abstract void Undo();
}

public class MoveForwardCommand: Command
{
    public override void Execute()
    {
        Input_Handler.Instance.GetPlayer().MoveForward();
    }
    public override void Undo()
    {
        Input_Handler.Instance.GetPlayer().MoveBackward();
    }
}

public class RotateRightCommand: Command
{
    public override void Execute()
    {
        Input_Handler.Instance.GetPlayer().RotateRight();
    }

    public override void Undo()
    {
        Input_Handler.Instance.GetPlayer().RotateLeft();
    }
}

public class RotateLeftCommand: Command
{
    public override void Execute()
    {
        Input_Handler.Instance.GetPlayer().RotateLeft();
    }
    public override void Undo()
    {
        Input_Handler.Instance.GetPlayer().RotateRight();
    }
}
public class InteractCommand: Command
{
    public override void Execute()
    {
        Input_Handler.Instance.GetPlayer().Interact(true);
    }

    public override void Undo()
    {
        Input_Handler.Instance.GetPlayer().Interact(false);
    }
}