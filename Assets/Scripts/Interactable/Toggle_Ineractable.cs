using DG.Tweening;
using UnityEngine;

public class Toggle_Ineractable : Interactable
{
    public bool multiTrigger = false;

    [SerializeField] private Renderer _renderer;

    [SerializeField] private Color offColor, onColor;
    private bool triggered = false;

    void Start()
    {
        TurnOffObject();
    }

    public override void Interact()
    {
        if (multiTrigger)
        {
            if (!triggered)
            {
                triggered = true;
                TurnOnObject();
            }
            else
            {
                triggered = false;
                TurnOffObject();
            }
            return;
        }

        TurnOnObject();
    }

    public override void Undo()
    {
        if (multiTrigger)
        {
            if (!triggered)
            {
                triggered = true;
                TurnOnObject();
            }
            else
            {
                triggered = false;
                TurnOffObject();
            }
            return;
        }

        TurnOffObject();
    }

    private void TurnOnObject()
    {   
        base.Interact();
        Debug.Log("Enter here");
        _renderer.material.DOColor(onColor, Speed_Manager.instance._globalSpeed);
    }

    private void TurnOffObject()
    {
        base.Undo();
        _renderer.material.DOColor(offColor, Speed_Manager.instance._globalSpeed);
    }
}
