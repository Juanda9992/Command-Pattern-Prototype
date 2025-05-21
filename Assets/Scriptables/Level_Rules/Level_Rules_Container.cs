using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Rules Container", menuName = "Scriptables/Level Rules/Level Rules Container")]
public class Level_Rules_Container : ScriptableObject
{
    public List<Level_Rules_Data> allLevelsData;

    public Level_Rules_Data GetLevelRules(int index)
    {
        return allLevelsData[index];
    }
}
