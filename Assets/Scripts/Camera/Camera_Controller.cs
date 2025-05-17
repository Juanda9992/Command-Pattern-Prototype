using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 followOffset;
    [SerializeField] private Vector3 defaultOffset;

    [Header("Zoom Settings")]
    [SerializeField] private float minZoom;
    [SerializeField] private float maxZoom;
    private Camera mainCamera;
    private float currentZoom;

    void Awake()
    {
        mainCamera = GetComponent<Camera>();
        followOffset = defaultOffset;
    }
    void LateUpdate()
    {
        transform.DOMove(player.position + followOffset,0.5f);

        currentZoom += Input_Actions_Manager.instance.GetCameraScroll();
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        PanCamera();

        mainCamera.DOOrthoSize(currentZoom, 0.4f);
    }

    private void PanCamera()
    {
        Vector2 movingVectorreference = defaultOffset;
        switch (Input_Actions_Manager.instance.GetMouseBoundsPos())
        {
            case Input_Actions_Manager.MouseEdgePosition.Bottom:
                followOffset.z = defaultOffset.z - 1;
                followOffset.x = defaultOffset.x - 1;
                break;
            case Input_Actions_Manager.MouseEdgePosition.Upper:
                followOffset.z = defaultOffset.z + 1;
                followOffset.x = defaultOffset.x + 1;
                break;
            case Input_Actions_Manager.MouseEdgePosition.Left:
                followOffset.x = defaultOffset.x - 1;
                followOffset.z = defaultOffset.z + 1;
                break;
            case Input_Actions_Manager.MouseEdgePosition.Right:
                followOffset.x = defaultOffset.x + 1;
                followOffset.z = defaultOffset.z - 1;
                break;
            case Input_Actions_Manager.MouseEdgePosition.None:
                followOffset = defaultOffset;
                break;
        }
    }
}

