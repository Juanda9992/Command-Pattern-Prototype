using UnityEngine;

[CreateAssetMenu(fileName = "Level_x_Rule",menuName = "Scriptables/Level Rules/ Level Rule Data")]
public class Level_Rules_Data : ScriptableObject
{
    [SerializeField,TextArea] private string levelSummary;
    public string levelJsonName;
    public bool moveNextButton = true;
    public bool rotateLeftButton = true;
    public bool rotateTightButton = true;
    public bool interactButton = true;
    [Range(-1, 15)] public int maxBlockLimit = -1;
    public int playerRotation;
    [Range(5, 12)] public int cameraZoom = 6;
}
