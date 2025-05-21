using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Rules_Manager : MonoBehaviour
{
    public int level = 0;
    private static Level_Rules_Data activeLevelRules;
    [SerializeField] private Level_Rules_Container level_Rules_Container;

    [SerializeField] private Transform playerTransform;

    [SerializeField] private GameObject leftButton, rightButton, moveButton, interactButton;
    [SerializeField] private Camera_Controller camera_Controller;

    public void LoadRules()
    {
        activeLevelRules = level_Rules_Container.GetLevelRules(level);

        SetPlayerInitialPosition();
        playerTransform.rotation = Quaternion.Euler(0, activeLevelRules.playerRotation, 0);


        leftButton.SetActive(activeLevelRules.rotateLeftButton);
        rightButton.SetActive(activeLevelRules.rotateTightButton);
        moveButton.SetActive(activeLevelRules.moveNextButton);
        interactButton.SetActive(activeLevelRules.interactButton);

        camera_Controller.SetCameraZoom(activeLevelRules.cameraZoom);
    }

    private void SetPlayerInitialPosition()
    {
        try
        {
            playerTransform.position = GameObject.FindWithTag("Starting_Point").transform.position + Vector3.up;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public static Level_Rules_Data GetActiveLevelRules()
    {
        return activeLevelRules;
    }
}
