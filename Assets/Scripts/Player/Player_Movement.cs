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
}
