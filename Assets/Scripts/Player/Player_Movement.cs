using DG.Tweening;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Transform interactOrigin;
    [SerializeField] private float moveTime;

    [ContextMenu("Move Forward")]
    public void MoveForward()
    {
        transform.DOLocalMove(transform.position +transform.forward,moveTime);
    }

    [ContextMenu("Move Backward")]
    public void MoveBackward()
    {
        transform.DOLocalMove(transform.position -transform.forward,moveTime);
    }

    [ContextMenu("Rotate Left")]
    public void RotateLeft()
    {
        transform.DOLocalRotate(Vector3.up * -90,moveTime,RotateMode.WorldAxisAdd);
    }

    [ContextMenu("Rotate Right")]
    public void RotateRight()
    {
        transform.DOLocalRotate(Vector3.up * 90,moveTime,RotateMode.WorldAxisAdd);
    }

    [ContextMenu("Interact")]
    public void Interact(bool forwardInteraction)
    {
        RaycastHit hit;
        Ray ray = new Ray(interactOrigin.position, transform.forward);
        if(Physics.Raycast(ray, out hit,0.5f))
        {
            if(hit.collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                if(forwardInteraction)
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
}
