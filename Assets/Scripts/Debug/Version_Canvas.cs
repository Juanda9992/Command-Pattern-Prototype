using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Version_Canvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI fpsText;
    [SerializeField] private TextMeshProUGUI versionText;
    [SerializeField] private string dateVersion;
    [SerializeField] private float fps;

    [ContextMenu("Get Date Version")]
    private void GetDateVersion()
    {
        dateVersion = System.DateTime.Now.ToString();
    }

    void Awake()
    {
        versionText.text = Application.productName + " Build " + Application.version + " " + dateVersion;

        StartCoroutine("GetFPS");
    }

    private IEnumerator GetFPS()
    {
        while(true)
        {
            fps = 1f / Time.unscaledDeltaTime;
            fpsText.text = fps.ToString("F1");
            yield return new WaitForSeconds(0.5f);
        }
    }
}
