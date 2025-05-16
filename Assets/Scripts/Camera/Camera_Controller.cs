using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 followOffset;

    void LateUpdate()
    {
        transform.position = player.position + followOffset;
    }
}
