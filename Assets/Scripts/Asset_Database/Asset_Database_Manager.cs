using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asset_Database_Manager : MonoBehaviour
{
    [SerializeField] private Button_Assets button_Assets;

    public static Asset_Database_Manager instance;

    void Awake()
    {
        instance = this;
    }

    public Sprite GetButtonSprite(int index)
    {
        return button_Assets.actionButtons[index];
    }
}
