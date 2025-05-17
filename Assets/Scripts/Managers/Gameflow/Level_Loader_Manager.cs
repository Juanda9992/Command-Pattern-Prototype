using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader_Manager : MonoBehaviour
{
    public static Level_Loader_Manager instance;

    void Awake()
    {
        instance = this;
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
