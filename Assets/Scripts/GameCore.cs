using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameCore : MonoBehaviour
{
    public static Action FailGameEvent;
    public static Action WinGameEvent;

    private void OnEnable()
    {
        FailGameEvent += DebugFail;
        WinGameEvent += DebugWin;
    }

    private void OnDisable()
    {
        FailGameEvent -= DebugFail;
        WinGameEvent -= DebugWin;
    }

    private void Start()
    {
        Logging.Write("Start Game");
    }

    private void DebugFail()
    {
        Logging.Write("Fail Game");
    }
    private void DebugWin()
    {
        Logging.Write("Win Game");
    }
}
