using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_Actions_Manager : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    public static Input_Actions_Manager instance;

    [SerializeField] private float screenBorderThreshold;

    public enum MouseEdgePosition { Upper, Bottom, Left, Right, None }
    void Awake()
    {
        instance = this;
        inputActions.Enable();

        Debug.Log(Screen.width + " " + Screen.height);
    }

    void Update()
    {
    }
    public float GetCameraScroll()
    {
        return inputActions.FindAction("Scroll").ReadValue<float>();
    }

    public Vector2 GetMousePos()
    {
        return inputActions.FindAction("Mouse Position").ReadValue<Vector2>();
    }

    public MouseEdgePosition GetMouseBoundsPos()
    {
        if (GetMousePos().x > Screen.width * screenBorderThreshold)
        {
            return MouseEdgePosition.Right;
        }

        if (GetMousePos().x < Screen.width - (Screen.width * screenBorderThreshold))
        {
            return MouseEdgePosition.Left;
        }

        if (GetMousePos().y > Screen.height * screenBorderThreshold)
        {
            return MouseEdgePosition.Upper;
        }

        if (GetMousePos().y < Screen.height - (Screen.height * screenBorderThreshold))
        {
            return MouseEdgePosition.Bottom;
        }

        return MouseEdgePosition.None;
    }

    public bool GetKeyPressedThisFrame(string keyName)
    {
        return inputActions.FindActionMap("Keyboard Actions").FindAction(keyName).WasPressedThisFrame();
    }
}
