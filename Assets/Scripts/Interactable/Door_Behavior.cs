using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Door_Behavior : Interactable
{
    public int id;
    public bool canInteract = true;
    [SerializeField] private Collider doorCollider;
    [SerializeField] private GameObject visual;
    private Vector3 initialPos;
    private Vector3 finalPos;

    void Awake()
    {
        initialPos = visual.transform.localPosition;
        finalPos = visual.transform.localPosition + new Vector3(0, 3, 0);
    }

    public override void Interact()
    {
        if (canInteract)
        {
            visual.transform.DOLocalMove(finalPos, Speed_Manager.instance._globalSpeed);
            doorCollider.isTrigger = true;
        }

    }
    public override void Undo()
    {
        visual.transform.DOLocalMove(initialPos, Speed_Manager.instance._globalSpeed);
        doorCollider.isTrigger = false;
    }

    public void RemoteInteraction()
    {
        visual.transform.DOLocalMove(finalPos, Speed_Manager.instance._globalSpeed);
        doorCollider.isTrigger = true;
    }

    void OnEnable()
    {
        Level_Loader_Manager.OnRestartLevel += Undo;
    }

    void OnDisable()
    {
        Level_Loader_Manager.OnRestartLevel -= Undo;
    }
}

