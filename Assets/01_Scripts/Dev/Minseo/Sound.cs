using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class Sound : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    public void SetMuisc(float volume)
    {
        audioSource.volume = volume;
    }
}
