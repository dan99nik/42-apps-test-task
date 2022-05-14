using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGameStatus : MonoBehaviour
{
    private const string _winTag = "Win";
    private const string _loseTag = "Lose";

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == _winTag)
            GameCore.WinGameEvent?.Invoke();

        if (other.tag == _loseTag)
            GameCore.FailGameEvent?.Invoke();
    }
}
