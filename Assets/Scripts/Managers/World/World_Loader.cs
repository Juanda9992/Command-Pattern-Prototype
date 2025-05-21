using System.Collections;
using System.Collections.Generic;
using TWC;
using UnityEngine;

public class World_Loader : MonoBehaviour
{
    [SerializeField] private string worldName;

    [SerializeField] private TileWorldCreator tileWorldCreator;

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
        }
        else
        {
            Debug.LogWarning("There is not file for world " + worldName);
        }
    }
}
