using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float time;

    bool timerActive;

    private void Start()
    {
        timerActive = false;
    }

    private void Update()
    {
        colourChange();

        if (timerActive)
        {
            time += Time.deltaTime;

            timerText.text = ("Time: " + time);
        }
        else
        {
            timerText.text = ("Time: " + time);
        }       
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    void colourChange()
    {
        if(time >= 45)
        {
            timerText.color = new Color(0.812f, 0.667f, 0.200f, 1);
        }
        else if(time >= 90)
        {
            timerText.color = new Color(0.753f, 0.753f, 0.753f, 1);
        }
        else if(time >= 145)
        {
            timerText.color = new Color(0.804f, 0.500f, 0.200f, 1);
        }
        else
        {
            timerText.color = Color.white;
        }


    }


}
