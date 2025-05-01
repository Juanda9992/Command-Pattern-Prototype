using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Interactable : Interactable
{
    public override void Interact()
    {
        Debug.Log("Interacted with debug cube");
    }
}
