using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom_Data_Loader : MonoBehaviour
{
    private List<GameObject> customObjectsInScene = new List<GameObject>();
    public void SetCustomLevelData(Custom_Loading_Data data)
    {
        Debug.Log("Custom Data exist with" + data.customInstructions.Length + " instructions");

        if (data.custom_Winning_Condition.winCondition != Custom_Winning_Condition.WinCondition.None)
        {
            Custom_Gameflow_Manager.instance.SetWinCondition(data.custom_Winning_Condition);
        }
        GameObject currentObject;
        Custom_Loading_Instruction instruction;
        for (int i = 0; i < data.customInstructions.Length; i++)
        {
            instruction = data.customInstructions[i];
            currentObject = Instantiate(instruction.customObject, instruction.customObjectPos, Quaternion.identity);

            customObjectsInScene.Add(currentObject);

            ExecuteAction(instruction, currentObject);

            SetObjectAction(currentObject, instruction.objectData);
        }

        if (!data.endingPlatform)
        {
            StartCoroutine(nameof(DisableEndingPoint));
        }


    }

    private void SetObjectAction(GameObject gameObject, string data)
    {
        if (data == "noDoorInteraction")
        {
            gameObject.GetComponent<Door_Behavior>().canInteract = false;
        }

        if (data == "noToggle")
        {
            gameObject.GetComponent<Toggle_Ineractable>().multiTrigger = false;
        }
    }
    private void ExecuteAction(Custom_Loading_Instruction instruction, GameObject logicObject)
    {
        Custom_Event_Data data;
        Interactable interactable = logicObject.GetComponent<Interactable>();
        for (int i = 0; i < instruction.events.Length; i++)
        {

            data = instruction.events[i];

            switch (data.eventType)
            {
                case Custom_Event_Data.EventType.Log:
                    string message = data.parameters;
                    interactable.interactAction += () => { Debug.Log(message); };
                    break;
                case Custom_Event_Data.EventType.Winning:
                    interactable.interactAction += () => { Level_Loader_Manager.instance.ShowWinCanvas(); };
                    break;

                case Custom_Event_Data.EventType.Door:
                    interactable.interactAction += () => { GameObject.FindObjectOfType<Door_Behavior>().RemoteInteraction(); };
                    interactable.undoAction += () => { GameObject.FindObjectOfType<Door_Behavior>().Undo(); };
                    break;

                case Custom_Event_Data.EventType.Counter:
                    interactable.interactAction += () => Custom_Gameflow_Manager.instance.IncreaseNumber();
                    interactable.undoAction += () => Custom_Gameflow_Manager.instance.DecreaseNumber();
                    break;
            }

        }
    }

    public void DeleteCustomObjects()
    {
        for (int i = 0; i < customObjectsInScene.Count; i++)
        {
            Destroy(customObjectsInScene[i]);
        }

        customObjectsInScene.Clear();
    }

    private IEnumerator DisableEndingPoint()
    {
        yield return new WaitForEndOfFrame();
        GameObject go = GameObject.FindWithTag("End_Point");
        go.SetActive(false);
    }
}
