using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource orcaVibes, sunset, emptyMind;

    private static AudioManager music = null;          //sets it as a singleton so it can be changed on scenes.
    public static AudioManager Music
    {
        get { return music; }
    }

    void Awake()
    {
        if (music != null && music != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else                                          //doesn't destory the item the music is on when it loads the game
        {
            music = this;
        }
        DontDestroyOnLoad(this.gameObject);

        sunset.Stop();
        emptyMind.Stop();
        orcaVibes.Play();
    }

    public void HandleInputData(int val)
    {
        if(val == 0)
        {
            sunset.Stop();
            emptyMind.Stop();
            orcaVibes.Play();
        }
        if (val == 1)
        {
            emptyMind.Stop();
            orcaVibes.Stop();
            sunset.Play();
        }
        if (val == 2)
        {
            sunset.Stop();
            orcaVibes.Stop();
            emptyMind.Play();
        }
    }
}
