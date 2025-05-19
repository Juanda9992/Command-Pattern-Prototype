using UnityEngine;
[System.Serializable]
public class Level_Rules_Data
{
    public bool moveNextButton = true;
    public bool rotateLeftButton = true;
    public bool rotateTightButton = true;
    public bool interactButton = true;
    public int maxBlockLimit = -1;
    public int playerRotation;
    public Vector3 playerPosition = Vector3.up;
    public int cameraZoom = 6;
}
