using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{

    public Interactable toggleDoor;
    public Animator doorAnim;
    
    private bool _isOpen;
    public string animBool;

    private void OnEnable()
    {
        if(toggleDoor)
        {
            toggleDoor.GetInteractEvent.HasInteracted += DoorToggle;
        }
    }

    private void OnDisable()
    {
        if(toggleDoor)
        {
            toggleDoor.GetInteractEvent.HasInteracted -= DoorToggle;
        }
    }  

    public void DoorToggle()
    {
        _isOpen = !_isOpen;
    }

    private void FixedUpdate()
    {
        doorAnim.SetBool(animBool, _isOpen);
    }
}