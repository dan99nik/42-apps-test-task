using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _failScreen;
    [SerializeField] private GameObject _winScreen;

    private void OnEnable()
    {
        GameCore.FailGameEvent += FailGameUI;
        GameCore.WinGameEvent += WinGameUI;
    }
    private void OnDisable()
    {
        GameCore.FailGameEvent -= FailGameUI;
        GameCore.WinGameEvent -= WinGameUI;
    }

    private void FailGameUI()
    {
        _failScreen.SetActive(true);
    }

    private void WinGameUI()
    {
        _winScreen.SetActive(true);
    }
}
