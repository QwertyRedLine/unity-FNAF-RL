using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SFX : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx;
    public AudioClip InteractSfx;
    public Interactable playSfx;

    public bool needsInteraction;

    private void OnEnable()
    {
        if(playSfx)
        {
            playSfx.GetInteractEvent.HasInteracted += PlayAudio;
        }
    }

    private void OnDisable()
    {
        if(playSfx)
        {
            playSfx.GetInteractEvent.HasInteracted -= PlayAudio;
        }
    }    

    public void PlayAudio()
    {
        if(playSfx)
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
