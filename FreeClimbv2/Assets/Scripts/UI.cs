using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Main Game");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void SpeedRun()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
