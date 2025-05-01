using DG.Tweening;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float moveTime;

    [ContextMenu("Move Forward")]
    public void MoveForward()
    {
        transform.DOLocalMove(transform.position +transform.forward,moveTime);
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
}
