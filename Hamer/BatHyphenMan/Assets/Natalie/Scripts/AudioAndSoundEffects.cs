using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAndSoundEffects : MonoBehaviour
{

    public Game_Manager GM;
    public AudioClip[] SoundEffects;
    public bool PlayingSound;
    public int CurrentSound;
    public AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
       // SoundEffects = new AudioClip[10];
        AS = gameObject.GetComponent<AudioSource>();
        PlayingSound = false;
    }

    // Update is called once per frame
    void Update()
    {
        AS.clip = SoundEffects[CurrentSound];

        if (PlayingSound == false)
        {
            AS.Play();
        }

        if (AS.isPlaying)
        {
            PlayingSound = true;
        }

        else if (!AS.isPlaying)
        {
            PlayingSound = false;
            CurrentSound = 0;
        }
    }


}
