using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public Button[] checkpoints;

    private void Awake()
    {
        foreach (Button checkpoint in checkpoints)
        {
            checkpoint.enabled = false;
        }
        
    }

    public void CheckPoint1Activated()
    {
        checkpoints[0].enabled = true;
    }

    public void CheckPoint2Activated()
    {
        checkpoints[1].enabled = true;
    }

    public void CheckPoint3Activated()
    {
        checkpoints[2].enabled = true;
    }

    public void CheckPoint4Activated()
    {
        checkpoints[3].enabled = true;
    }
}