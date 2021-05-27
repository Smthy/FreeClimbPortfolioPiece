using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientNoise : MonoBehaviour
{
    public AudioSource[] audios;
    public AudioSource current;
    private int index;

    private void Start()
    {
        StartCoroutine("RandomAudio");
    }

    IEnumerator RandomAudio()
    {
        index = Random.Range(0, audios.Length);
        current = audios[index];
        current.Play();

        float randomTimeLimit = Random.Range(5f, 15f);
        yield return new WaitForSeconds(randomTimeLimit);

        StartCoroutine("RandomAudio");
    }
}
