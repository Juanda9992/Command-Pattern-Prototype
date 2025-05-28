using System.Collections;
using System.Collections.Generic;
using TWC;
using UnityEngine;
using UnityEngine.Events;

public class World_Loader : MonoBehaviour
{
    [SerializeField] private string worldName;

    [SerializeField] private TileWorldCreator tileWorldCreator;

    [SerializeField] private UnityEvent OnWorldBuilded;

    void Awake()
    {
        tileWorldCreator.OnBuildLayersComplete += delegate { OnWorldBuilded?.Invoke();};
    }

    [ContextMenu("Save")]
    public void SaveMap()
    {
        if (!System.IO.Directory.Exists(Application.streamingAssetsPath))
        {
            Debug.LogError("Directory does not exist. Please create a new Streaming Assets folder");
            return;
        }

        var _path = Application.streamingAssetsPath + "/" + worldName + ".json";
        tileWorldCreator.SaveBlueprintStack(_path);
    }

    [ContextMenu("Load")]
    public void LoadMap()
    {
        var _path = Application.streamingAssetsPath + "/" + worldName + ".json";
        if (System.IO.File.Exists(_path))
        {
            Debug.Log("Exist file");
            tileWorldCreator.LoadBlueprintStack(_path);

            tileWorldCreator.ExecuteAllBlueprintLayers();
            tileWorldCreator.ExecuteAllBuildLayers(true);

            ExecuteCustomLoadingData();
        }
        else
        {
            Debug.LogWarning("There is not file for world " + worldName);
        }
    }

    private void ExecuteCustomLoadingData()
    {
        if (Level_Rules_Manager.GetActiveLevelRules().custom_Loading_Data != null)
        {
            Custom_Loading_Data data = Level_Rules_Manager.GetActiveLevelRules().custom_Loading_Data;
            Debug.Log("Custom Data exist with" + data.customInstructions.Length + " instructions");
        }
    }

    public void SetWorldName()
    {
        worldName = Level_Rules_Manager.GetActiveLevelRules().name.ToLower();

        LoadMap();
    }
}
