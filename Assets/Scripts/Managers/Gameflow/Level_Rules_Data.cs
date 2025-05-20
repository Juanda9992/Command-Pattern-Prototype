using UnityEngine;
[System.Serializable]
public class Level_Rules_Data
{
    public bool moveNextButton = true;
    public bool rotateLeftButton = true;
    public bool rotateTightButton = true;
    public bool interactButton = true;
    [Range(-1,15)] public int maxBlockLimit = -1;
    public int playerRotation;
    [Range(5,12)]public int cameraZoom = 6;
}
