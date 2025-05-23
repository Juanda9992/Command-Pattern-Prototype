using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_Manager : MonoBehaviour
{
    public float _globalSpeed;
    public static Speed_Manager instance;

    void Awake()
    {
        instance = this;
    }
}
