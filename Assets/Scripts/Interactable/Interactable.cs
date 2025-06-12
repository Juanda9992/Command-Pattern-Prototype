using System;
using System.Collections;
using UnityEngine;
public class Interactable : MonoBehaviour
{
    public Action undoAction;
    public Action interactAction;
    [SerializeField] private Interactable_Animation animateObject;

    [SerializeField] private bool executeWithDelay = false;
    public virtual void Interact()
    {
        if (!executeWithDelay)
        {
            animateObject.AnimateIn();
            interactAction?.Invoke();
        }
        else
        {
            StartCoroutine(nameof(InteractWithDelay));
        }
    }

    private IEnumerator InteractWithDelay()
    {
        animateObject.AnimateIn();
        yield return new WaitForSeconds(Speed_Manager.instance._globalSpeed / 2);
        interactAction?.Invoke();
    }

    private IEnumerator ReverseWithDelay()
    {
        animateObject.AnimateOut();
        yield return new WaitForSeconds(Speed_Manager.instance._globalSpeed / 2);
        undoAction?.Invoke();
    }

    public virtual void Undo()
    {
        if (!executeWithDelay)
        {
            animateObject.AnimateOut();
            undoAction?.Invoke();
        }
        else
        {
            StartCoroutine(nameof(ReverseWithDelay));
        }
    }
}
