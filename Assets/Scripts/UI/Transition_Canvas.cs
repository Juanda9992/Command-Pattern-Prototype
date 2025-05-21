using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Transition_Canvas : MonoBehaviour
{
    [SerializeField] private float fadeInTime, holdTime, fadeOutTime;

    [SerializeField] private CanvasGroup canvasGroup;

    public static Transition_Canvas instance;

    void Awake()
    {
        instance = this;
    }

    public void SetTransition(Action transitionAction)
    {
        canvasGroup.DOFade(1, fadeInTime).OnComplete(() => transitionAction?.Invoke());

        canvasGroup.DOFade(0, fadeOutTime).SetDelay(fadeInTime + holdTime);
    }
}
