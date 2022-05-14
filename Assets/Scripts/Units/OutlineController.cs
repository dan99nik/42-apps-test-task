using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

public class OutlineController : MonoBehaviour
{
    [SerializeField] private Outlinable _outlinable;
    [SerializeField] private Color[] _colors;

    private void OnMouseEnter()
    {
        _outlinable.FrontParameters.FillPass.SetColor("_PublicColor", _colors[0]);
    }

    private void OnMouseExit()
    {
        _outlinable.FrontParameters.FillPass.SetColor("_PublicColor", _colors[1]);
    }
}
