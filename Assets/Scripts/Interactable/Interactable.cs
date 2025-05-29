using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public Action interactAction;

    public virtual void Interact()
    {
        interactAction?.Invoke();
    }

    public virtual void Undo()
    {

    }
}
