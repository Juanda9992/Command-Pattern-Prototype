using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Actions_Manager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    public static Input_Actions_Manager instance;
    void Awake()
    {
        instance = this;
        inputActions.Enable();
    }
    public float GetCameraScroll()
    {
        return inputActions.FindAction("Scroll").ReadValue<float>();
    }
}
