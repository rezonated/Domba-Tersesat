﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromSoundFX : MonoBehaviour
{
    private AudioSource audioFX;

    private void Awake()
    {
        audioFX = GetComponent<AudioSource>();
    }

    public void PlayAudio(bool play)
    {
        if (play)
        {
            audioFX.Play();
        }
        else
        {
            audioFX.Stop();
        }
    }
}
