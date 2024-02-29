using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    private bool canInteract;
    
    public UnityEvent Interacted;

    public void Interaction()
    {
        if(canInteract)
        {
            Interacted.Invoke();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canInteract = true;
            Debug.Log("entered");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            canInteract = false;
            Debug.Log("exited");
        }
    }
}
