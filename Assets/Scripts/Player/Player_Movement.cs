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
        Collider colliderInFront = CheckForObjectInFront();
        Collider objInGround = CheckObjectInGround();

        if (colliderInFront != null && !colliderInFront.isTrigger)
        {
            Input_Handler.Instance.StopReplay();
            Debug.Log(colliderInFront.name);
            return;
        }
        if (objInGround == null)
            {
                return;
            }
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
        Collider objInFront = CheckForObjectInFront();
        if (objInFront != null)
        {
            if (objInFront.TryGetComponent<Interactable>(out Interactable interactable))
            {
                Debug.Log(objInFront.name);
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
        else
        {
            Debug.Log("Nothing");
        }
    }

    private Collider CheckForObjectInFront()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(interactOrigin.position, transform.forward);
        if (Physics.Raycast(ray, out hit, 0.5f))
        {
            return hit.collider;
        }
        return null;
    }

    private Collider CheckObjectInGround()
    {
        Collider[] groundPos = Physics.OverlapSphere(groundCheckingTransform.position, 0.1f);
        if (groundPos.Length > 0)
        {
            return groundPos[0];
        }
        return null;
    }

    public void CheckForCompletion()
    {
        Collider groundObj = CheckObjectInGround();
        if (groundObj != null)
        {
            if (groundObj.CompareTag("End_Point"))
            {
                OnPlayerWin?.Invoke();
                Debug.Log("Player ended");
            }
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
