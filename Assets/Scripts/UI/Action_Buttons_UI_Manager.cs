using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Action_Buttons_UI_Manager : MonoBehaviour
{
    [SerializeField] private Transform buttonsParent;
    [SerializeField] private GameObject buttonsPrefab;

    [SerializeField] private List<GameObject> allButtonsStored;

    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private GameObject highlightButton;

    [SerializeField] private TextMeshProUGUI blocksText;

    [SerializeField] private Color highlightCorrect, highlightIncorrect;

    private Image highlightImage;

    void Start()
    {
        highlightImage = highlightButton.GetComponent<Image>();
        SetBlockText();
    }

    private void SetBlockText()
    {
        blocksText.text = allButtonsStored.Count + "/" + Level_Rules_Manager.GetActiveLevelRules().maxBlockLimit;
    }
    public void InstantiateButton(ActionType actionType)
    {
        GameObject currentButton = Instantiate(buttonsPrefab, buttonsParent);
        currentButton.SetActive(true);
        currentButton.GetComponent<Action_Container_Button>().SetActionType(actionType, allButtonsStored.Count);

        allButtonsStored.Add(currentButton);
        SetBlockText();
    }

    public void RemoveLastAction()
    {
        Destroy(allButtonsStored[allButtonsStored.Count - 1]);
        allButtonsStored.RemoveAt(allButtonsStored.Count - 1);

        MoveHightlightToButton(allButtonsStored.Count - 1);
        SetBlockText();
    }

    public void RemoveActionAt(int index)
    {
        highlightButton.transform.SetParent(null);
        allButtonsStored.RemoveAt(index);
        RecalculateButtonsIndex();
        SetBlockText();
    }

    private void RecalculateButtonsIndex()
    {
        for (int i = 0; i < allButtonsStored.Count; i++)
        {
            allButtonsStored[i].GetComponent<Action_Container_Button>().SetButtonIndex(i);
        }

    }

    public void MoveHightlightToButton(int index)
    {
        if (index >= 0)
        {
            SetHightlightButtonStatus(false);
            highlightButton.SetActive(true);

            highlightButton.transform.parent = allButtonsStored[index].transform;
            highlightButton.transform.localPosition = Vector2.zero;
        }
        else
        {
            highlightButton.SetActive(false);
        }

        if (highlightButton.transform.position.y < 490)
        {
            Debug.Log(highlightButton.transform.position.y);
            if (scrollbar.value > 0.1)
            {
                scrollbar.value -= 0.2f;
            }
        }
    }

    public void SetHightlightButtonStatus(bool wrong)
    {
        highlightImage.color = wrong ? highlightIncorrect : highlightCorrect;
    }

    public void ResetToDefault()
    {
        highlightButton.transform.SetParent(null);
        highlightButton.SetActive(false);
        for (int i = 0; i < allButtonsStored.Count; i++)
        {
            Destroy(allButtonsStored[i]);
        }
        allButtonsStored.Clear();
        SetBlockText();
    }
}
