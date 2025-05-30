using UnityEditor;
using UnityEngine;

public class DeleteWorld : Editor
{
    [MenuItem("Editor Tools/Delete World")]
    public static void DeleteWorldTool()
    {
        GameObject map = GameObject.Find("TileWorldMap");
        DestroyImmediate(map);
    }
}
