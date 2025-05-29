using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public Action interactAction;

    public void Interact()
    {
        interactAction?.Invoke();
    }
}
