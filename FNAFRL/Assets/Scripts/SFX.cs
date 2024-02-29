using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SFX : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx;
    public AudioClip InteractSfx;

    public bool needsInteraction;
    

    public void PlayAudio()
    {
        if(needsInteraction)
        {
            src.clip = InteractSfx;
            src.Play();
        }
        else
        {
            src.clip = sfx;
            src.Play();
        }
    }
}
