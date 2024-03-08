using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    public Interactable pickupFlashlight;

    public static bool pickedup;


    private void OnEnable()
    {
        if(pickupFlashlight)
        {
            pickupFlashlight.GetInteractEvent.HasInteracted += Pickup;
        }
    }

    private void OnDisable()
    {
        if(pickupFlashlight)
        {
            pickupFlashlight.GetInteractEvent.HasInteracted -= Pickup;
        }
    }  

    public void Pickup()
    {
        pickedup = true;
        Destroy(gameObject);
    }
}