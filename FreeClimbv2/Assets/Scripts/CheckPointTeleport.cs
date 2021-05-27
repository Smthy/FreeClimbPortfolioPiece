using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointTeleport : MonoBehaviour
{
    public GameObject player;
    public Transform[] tranforms;
    public Transform currentTransform;

    public CharacterController character;

    public AudioSource whoosh;

    private void Start()
    {        
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Button1()
    {
        character.enabled = false;
        
        currentTransform = tranforms[0];        
        player.transform.position = currentTransform.transform.position;
        whoosh.Play();

        character.enabled = true;

    }
    public void Button2()
    {
        character.enabled = false;

        currentTransform = tranforms[1];
        player.transform.position = currentTransform.transform.position;
        whoosh.Play();

        character.enabled = true;
    }
    public void Button3()
    {
        character.enabled = false;

        currentTransform = tranforms[2];
        player.transform.position = currentTransform.transform.position;
        whoosh.Play();

        character.enabled = true;
    }
    public void Button4()
    {
        character.enabled = false;

        currentTransform = tranforms[3];
        player.transform.position = currentTransform.transform.position;
        whoosh.Play();

        character.enabled = true;
    }
}
