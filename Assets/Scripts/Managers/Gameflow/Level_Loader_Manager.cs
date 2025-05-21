using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level_Loader_Manager : MonoBehaviour
{
    public int level = 0;
    [SerializeField] private Level_Rules_Manager level_Rules_Manager;
    [SerializeField] private World_Loader world_Loader;

    [SerializeField] private GameObject winCanvas;
    public static Level_Loader_Manager instance;
    public static Action OnRestartLevel;

    void Awake()
    {
        instance = this;
        Player_Movement.OnPlayerHitWrongSurface += RestartLevel;
    }

    void Start()
    {
        SetLevelLoadingLogic();
    }

    public void RestartLevel()
    {
        OnRestartLevel?.Invoke();
        level_Rules_Manager.LoadRules(level);
    }

    private void ShowWinCanvas()
    {
        winCanvas.SetActive(true);
    }

    private void SetLevelLoadingLogic()
    {
        level_Rules_Manager.SetActiveLevelRules(level);

        world_Loader.SetWorldName();

    }
    public void NextLevel()
    {
        level++;
        winCanvas.SetActive(false);
        Transition_Canvas.instance.SetTransition(() =>
        {
            SetLevelLoadingLogic();
        });

    }

    void Update()
    {
        if (Input_Actions_Manager.instance.GetKeyPressedThisFrame("R"))
        {
            RestartLevel();
        }
    }

    void OnEnable()
    {
        Player_Movement.OnPlayerWin += ShowWinCanvas;
    }
}
