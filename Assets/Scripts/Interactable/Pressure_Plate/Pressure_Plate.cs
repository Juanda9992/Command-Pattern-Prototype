using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pressure_Plate : MonoBehaviour
{   
    public UnityEvent executeEvent;
    public UnityEvent undoEvent;

    public virtual void Interact()
    {
        executeEvent?.Invoke();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Interact();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input_Handler.Instance.isUndoingCommand)
            {
                undoEvent?.Invoke();
            }
        }
    }
}
