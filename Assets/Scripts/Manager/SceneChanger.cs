using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void LoadMainScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void LoadIntroScene()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
