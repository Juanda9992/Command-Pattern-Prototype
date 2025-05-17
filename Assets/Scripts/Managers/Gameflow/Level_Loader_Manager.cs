using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Level_Loader_Manager : MonoBehaviour
{
    [SerializeField] private UnityEvent OnSceneLoaded;
    public static Level_Loader_Manager instance;

    void Awake()
    {
        instance = this;
        SceneManager.sceneLoaded += (x, y) => OnSceneLoaded?.Invoke();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (Input_Actions_Manager.instance.GetKeyPressedThisFrame("R"))
        {
            RestartLevel();
        }
    }
}
