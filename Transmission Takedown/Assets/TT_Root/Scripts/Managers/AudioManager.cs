using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    public static AudioManager Instance
    { get { return instance; } }

    [Header("AudioSource References")]

    public AudioSource sfxSource;

    [Header("Clip Configuration")]
    public AudioClip[] sfxArray;

    public void PlaySFX(int soundToPlay)
    {
        sfxSource.PlayOneShot(sfxArray[soundToPlay]);
    }
}
