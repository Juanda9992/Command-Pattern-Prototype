using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Interactable : MonoBehaviour
{
    public UnityEvent interactEvent;
    public UnityEvent reverseEvent;
    public abstract void Interact();
    public abstract void Undo();
}
