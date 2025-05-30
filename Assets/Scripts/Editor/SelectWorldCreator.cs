using TWC;
using UnityEditor;
using UnityEngine;

public class SelectWorldCreator : Editor
{
    [MenuItem("Editor Tools/Select World Creator")]
    public static void SelectWorldCreatorTool()
    {
        Selection.activeObject = GameObject.FindObjectOfType<TileWorldCreator>();
    }
}
