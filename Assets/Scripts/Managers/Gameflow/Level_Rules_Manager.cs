using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Rules_Manager : MonoBehaviour
{
    [SerializeField] private Level_Rules_Data level_Rules;

    [SerializeField] private Transform playerTransform;

    public void LoadRules()
    {
        playerTransform.position = level_Rules.playerPosition;
        playerTransform.rotation = Quaternion.Euler(0, level_Rules.playerRotation, 0);
    }
}
