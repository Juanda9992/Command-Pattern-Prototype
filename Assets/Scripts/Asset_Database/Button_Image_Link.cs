using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Image_Link : MonoBehaviour
{
    [SerializeField] private int spriteIndex;

    [SerializeField] private Image iconImage;

    void Start()
    {
        iconImage.sprite = Asset_Database_Manager.instance.GetButtonSprite(spriteIndex);
    }
}
