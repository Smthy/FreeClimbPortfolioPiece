using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Crashmat : MonoBehaviour
{
    public GameObject player;
    public Transform teleportZone;

    public CharacterController character;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            character.enabled = false;

            player.transform.position = teleportZone.transform.position;

            character.enabled = true;
        }
    }
}
