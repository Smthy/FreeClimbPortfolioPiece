using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject player;
    public Transform[] teleportLocation;
    private Transform currentTeleport;

   void Start()
   {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");


   }

    public void Teleport1()
    {
        currentTeleport = teleportLocation[0];

        Debug.Log("Final End Grabbed");
        player.transform.position = currentTeleport.transform.position;
    }

    public void Teleport2()
    {
        currentTeleport = teleportLocation[1];

        Debug.Log("Final End Grabbed");
        player.transform.position = currentTeleport.transform.position;
    }

}
