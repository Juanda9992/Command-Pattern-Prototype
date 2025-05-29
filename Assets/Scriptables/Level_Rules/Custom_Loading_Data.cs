using UnityEngine;

[CreateAssetMenu(fileName = "Level_x_Custom_Instructions", menuName = "Scriptables/Level Data/Custom Loading Instructions")]
public class Custom_Loading_Data : ScriptableObject
{
    public Custom_Loading_Instruction[] customInstructions;
    public bool endingPlatform = true;
}

[System.Serializable]
public class Custom_Loading_Instruction
{
    public GameObject customObject;
    public Vector3 customObjectPos;
    public Custom_Event_Data[] events;
}

[System.Serializable]
public class Custom_Event_Data
{
    public enum EventType {None,Log, Winning}
    public EventType eventType;
    public string parameters;
}
