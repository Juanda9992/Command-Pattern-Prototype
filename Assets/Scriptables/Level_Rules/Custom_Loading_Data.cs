using UnityEngine;

[CreateAssetMenu(fileName = "Level_x_Custom_Instructions", menuName = "Scriptables/Level Data/Custom Loading Instructions")]
public class Custom_Loading_Data : ScriptableObject
{
    public Custom_Loading_Instruction[] customInstructions;
    public Custom_Winning_Condition custom_Winning_Condition;
    public bool endingPlatform = true;
}

[System.Serializable]
public class Custom_Loading_Instruction
{
    public GameObject customObject;
    public Vector3 customObjectPos;
    public string objectData;
    public Custom_Event_Data[] events;
}

[System.Serializable]
public class Custom_Event_Data
{
    public enum EventType { None, Log, Winning, Door, Counter }
    public EventType eventType;
    public string parameters;
}

[System.Serializable]
public class Custom_Winning_Condition
{
    public enum WinCondition { None, Counter };
    public WinCondition winCondition;
    public string parameters;
}
