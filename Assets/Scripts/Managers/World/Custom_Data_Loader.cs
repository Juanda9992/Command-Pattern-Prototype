using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Data_Loader : MonoBehaviour
{
    public void SetCustomLevelData(Custom_Loading_Data data)
    {
        Debug.Log("Custom Data exist with" + data.customInstructions.Length + " instructions");
        GameObject currentObject;
        Custom_Loading_Instruction instruction;
        for (int i = 0; i < data.customInstructions.Length; i++)
        {
            instruction = data.customInstructions[i];
            currentObject = Instantiate(instruction.customObject, instruction.customObjectPos, Quaternion.identity);

            ExecuteAction(instruction,currentObject);
        }

    }
    private void ExecuteAction(Custom_Loading_Instruction instruction,GameObject logicObject)
    {
        Custom_Event_Data data;
        Interactable interactable = logicObject.GetComponent<Interactable>();
        for (int i = 0; i < instruction.events.Length; i++)
        {

            data = instruction.events[i];

            if (data.eventType == Custom_Event_Data.EventType.Log)
            {
                interactable.interactAction += () => { Debug.Log(data.parameters); };
            }
        }
    }
}
