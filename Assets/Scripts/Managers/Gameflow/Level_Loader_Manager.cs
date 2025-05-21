using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level_Loader_Manager : MonoBehaviour
{
    public int level = 0;
    [SerializeField] private Level_Rules_Manager level_Rules_Manager;
    [SerializeField] private World_Loader world_Loader;
    public static Level_Loader_Manager instance;
    public static Action OnRestartLevel;

    void Awake()
    {
        instance = this;
        Player_Movement.OnPlayerHitWrongSurface += RestartLevel;
    }

    void Start()
    {
        level_Rules_Manager.SetActiveLevelRules(level);

        world_Loader.SetWorldName();
    }

    public void RestartLevel()
    {
        OnRestartLevel?.Invoke();
        level_Rules_Manager.LoadRules(level);
    }

    void Update()
    {
        if (Input_Actions_Manager.instance.GetKeyPressedThisFrame("R"))
        {
            RestartLevel();
        }
    }
}
