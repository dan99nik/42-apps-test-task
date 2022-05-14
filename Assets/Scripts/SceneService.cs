using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneService : MonoBehaviour
{

    private void OnEnable()
    {
        GameCore.FailGameEvent += GameFinished;
        GameCore.WinGameEvent += GameFinished;
    }

    private void OnDisable()
    {
        GameCore.FailGameEvent -= GameFinished;
        GameCore.WinGameEvent -= GameFinished;
    }

    private void GameFinished()
    {
        Invoke("RestartScene", 1f);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
