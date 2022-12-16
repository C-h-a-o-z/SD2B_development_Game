using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneSwitcher : MonoBehaviour
{
    public string goTo;

    public void switchScene()
    {
        SceneManager.LoadScene(goTo);
    }

    public void quitBtn()
    {
        Application.Quit();
    }
}
