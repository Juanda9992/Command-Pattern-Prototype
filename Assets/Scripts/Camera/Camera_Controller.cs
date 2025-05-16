using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 followOffset;

    [Header("Zoom Settings")]
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    private Camera mainCamera;
    private float currentZoom;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }
    void LateUpdate()
    {
        transform.position = player.position + followOffset;

        currentZoom += Input_Actions_Manager.instance.GetCameraScroll();
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        mainCamera.DOOrthoSize(currentZoom, 0.4f);
    }
}
