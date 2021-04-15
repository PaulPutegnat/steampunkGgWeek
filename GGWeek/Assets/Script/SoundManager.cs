using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerMiss;
    static AudioSource audioSrc;

    void Start()
    {
        playerMiss = Resources.Load<AudioClip> ("Error");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip) {
        switch (clip) {
            case "Error":
                audioSrc.PlayOneShot(playerMiss);
                break;
        }
    }
}
