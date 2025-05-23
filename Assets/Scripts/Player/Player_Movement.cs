using System;
using DG.Tweening;
using TWC;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public static event Action OnPlayerHitWrongSurface;
    public static event Action OnPlayerWin;
    [SerializeField] private Transform interactOrigin;
    [SerializeField] private Transform groundCheckingTransform;

    [ContextMenu("Move Forward")]
    public void MoveForward()
    {
        transform.DOLocalMove(transform.position + transform.forward, Speed_Manager.instance._globalSpeed);
    }

    [ContextMenu("Move Backward")]
    public void MoveBackward()
    {
        transform.DOLocalMove(transform.position - transform.forward, Speed_Manager.instance._globalSpeed);
    }

    [ContextMenu("Rotate Left")]
    public void RotateLeft()
    {
        transform.DOLocalRotate(Vector3.up * -90, Speed_Manager.instance._globalSpeed, RotateMode.WorldAxisAdd);
    }

    [ContextMenu("Rotate Right")]
    public void RotateRight()
    {
        transform.DOLocalRotate(Vector3.up * 90, Speed_Manager.instance._globalSpeed, RotateMode.WorldAxisAdd);
    }

    [ContextMenu("Interact")]
    public void Interact(bool forwardInteraction)
    {
        RaycastHit hit;
        Ray ray = new Ray(interactOrigin.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            if (hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                if (forwardInteraction)
                {
                    interactable.Interact();
                }
                else
                {
                    interactable.Undo();
                }
            }
        }
    }

    public void CheckForCompletion()
    {
        Collider[] groundPos = Physics.OverlapSphere(groundCheckingTransform.position, 0.1f);
        if (groundPos[0].CompareTag("End_Point"))
        {
            OnPlayerWin?.Invoke();
            Debug.Log("Player ended");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Restart"))
        {
            OnPlayerHitWrongSurface?.Invoke();
        }
    }
}
