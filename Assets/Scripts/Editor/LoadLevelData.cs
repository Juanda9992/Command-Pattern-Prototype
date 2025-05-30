using UnityEditor;
using UnityEngine;

public class LoadLevelData : Editor
{

    [MenuItem("Editor Tools/Select Levels Container")]
    public static void SelectLevelsContainer()
    {
        string pathToData = "Assets/Scriptables/Level_Rules/Level Rules Container.asset";

        Level_Rules_Container l = AssetDatabase.LoadAssetAtPath<Level_Rules_Container>(pathToData);
        EditorGUIUtility.PingObject(l);
    }
}
