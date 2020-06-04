﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip[] PlayerSounds;
    public int CurrentSound;
    public bool AudioPlaying;
    public float AudioClipLength;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AudioClip[] PlayerSounds = new AudioClip[10];
    }

    // Update is called once per frame
    void Update()
    {
        AS.clip = PlayerSounds[CurrentSound];

        if (AudioPlaying == true)
        {
            AudioClipLength = PlayerSounds[CurrentSound].length;
            AS.Play();

            if (AS.isPlaying == true)
            {
                AudioPlaying = false;
            }

        }

        else if (AudioPlaying == false)
        {
            if (AudioClipLength > 0)
            {
                AudioClipLength -= Time.deltaTime;
            }

            else if (AudioClipLength <= 0)
            {
                CurrentSound = 0;
            }
        }
    }
}
