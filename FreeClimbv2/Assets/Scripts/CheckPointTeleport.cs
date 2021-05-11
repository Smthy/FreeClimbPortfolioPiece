using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTeleport : MonoBehaviour
{
    public GameObject player;
    public Transform[] tranforms;
    private Transform currentTransform;

    private void Start()
    {
        currentTransform.transform.position = player.transform.position;
    }

    public void button1()
    {
        tranforms[0] = currentTransform;

        player.transform.position = currentTransform.transform.position;
    }
    public void button2()
    {
        tranforms[1] = currentTransform;

        player.transform.position = currentTransform.transform.position;
    }
    public void button3()
    {
        tranforms[3] = currentTransform;

        player.transform.position = currentTransform.transform.position;
    }
    public void button4()
    {
        tranforms[4] = currentTransform;

        player.transform.position = currentTransform.transform.position;
    }
}
