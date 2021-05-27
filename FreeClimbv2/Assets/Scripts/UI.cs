using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Level2()
    {
        SceneManager.LoadScene("RealWorld");
    }

    public void SpeedRun()
    {
        SceneManager.LoadScene("SpeedRun");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
