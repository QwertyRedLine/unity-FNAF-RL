using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{

    public Interactable pushButton;
    public Animator dooranim;

    private bool _isOpen = true;

    private void OnEnable()
    {
        if(pushButton)
        {
            pushButton.GetInteractEvent.HasInteracted += Press;
        }
    }

    private void OnDisable()
    {
        if(pushButton)
        {
            pushButton.GetInteractEvent.HasInteracted -= Press;
        }
    }  

    public void Press()
    {
        _isOpen = !_isOpen;
    }

    private void FixedUpdate()
    {
        dooranim.SetBool("IsOpen?", _isOpen);
    }
}
