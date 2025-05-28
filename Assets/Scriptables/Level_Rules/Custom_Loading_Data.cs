using UnityEngine;

[CreateAssetMenu(fileName = "Level_x_Custom_Instructions",menuName = "Scriptables/Level Data/Custom Loading Instructions")]
public class Custom_Loading_Data : ScriptableObject
{
    [SerializeField, TextArea] private string[] customInstructions;
}
