using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChange : MonoBehaviour
{
    public Color startColor = Color.white;

    private Color _CorrectColor;

    public MeshRenderer meshRenderer;
    public float duration = 1f;

    private void OnValidate()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Start()
    {
        _CorrectColor = meshRenderer.materials[0].GetColor("_Color");
        LerpColor();
    }

    private void LerpColor()
    {
        meshRenderer.materials[0].SetColor("_Color", startColor);
        meshRenderer.materials[0].DOColor(_CorrectColor, duration).SetDelay(.5f);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            LerpColor();
        }

    }
}
