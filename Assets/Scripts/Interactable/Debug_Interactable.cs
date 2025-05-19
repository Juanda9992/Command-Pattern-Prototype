using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Interactable : Interactable
{
    public override void Interact()
    {
        interactEvent?.Invoke();
        Debug.Log("Interacted with debug cube");
    }

    public override void Undo()
    {
        Debug.Log("Cancel interaction");
    }
}
