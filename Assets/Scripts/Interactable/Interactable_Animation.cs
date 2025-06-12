using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Interactable_Animation : MonoBehaviour
{
    [SerializeField] private Vector3 initialPos, finalPos;

    public void AnimateIn()
    {
        transform.DOLocalMove(finalPos, Speed_Manager.instance._globalSpeed / 2).SetDelay(0.1f);
    }

    public void AnimateOut()
    {
        transform.DOLocalMove(initialPos, Speed_Manager.instance._globalSpeed / 2).SetDelay(0.1f);
    }
}
