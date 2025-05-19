using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Rules_Manager : MonoBehaviour
{
    private static Level_Rules_Data activeLevelRules;
    [SerializeField] private Level_Rules_Data level_Rules;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private GameObject leftButton, rightButton, moveButton, interactButton;
    [SerializeField] private Camera_Controller camera_Controller;

    public void LoadRules()
    {
        activeLevelRules = level_Rules;
        playerTransform.position = level_Rules.playerPosition;
        playerTransform.rotation = Quaternion.Euler(0, level_Rules.playerRotation, 0);


        leftButton.SetActive(level_Rules.rotateLeftButton);
        rightButton.SetActive(level_Rules.rotateTightButton);
        moveButton.SetActive(level_Rules.moveNextButton);
        interactButton.SetActive(level_Rules.interactButton);

        camera_Controller.SetCameraZoom(level_Rules.cameraZoom);
    }

    public static Level_Rules_Data GetActiveLevelRules()
    {
        return activeLevelRules;
    }
}
