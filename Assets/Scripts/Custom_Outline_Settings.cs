using UnityEngine;

public class Custom_Outline_Settings : MonoBehaviour
{
    [SerializeField] private Color outlineColor;
    [SerializeField] private float outlineThicknes;

    [SerializeField] private Renderer _renderer;
    void Start()
    {
        _renderer.materials[1].SetFloat("_Thickness", outlineThicknes);
        _renderer.materials[1].SetColor("_Outline_Color", outlineColor);
    }

#if UNITY_EDITOR
    void Update()
    {
        _renderer.materials[1].SetFloat("_Thickness", outlineThicknes);
        _renderer.materials[1].SetColor("_Outline_Color", outlineColor);

    }
#endif
}
