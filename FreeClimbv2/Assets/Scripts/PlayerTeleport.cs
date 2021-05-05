using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    public GameObject player;
    public Transform[] teleportLocation;
    private Transform currentTeleport;
    private int index = 0;

   void Start()
   {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");


   }

    public void Teleport()
    {
        currentTeleport = teleportLocation[index];

        Debug.Log("Final End Grabbed");
        player.transform.position = currentTeleport.transform.position;

        index ++;
    }

}
