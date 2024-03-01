using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{   
    InteractEvent Interact = new InteractEvent();
    Player player;

    public InteractEvent GetInteractEvent
    {

        get
        {
            if(Interact == null) Interact = new InteractEvent();
            return Interact;
        }
            
        
    }

    public Player getPlayer
    {
        get
        {
            return player;
        }
    }

    public void CallInteract(Player interactPlayer)
    {
        player = interactPlayer;
        Interact.Interacted();
    }

}

public class InteractEvent
{

    public delegate void Interact();

    public event Interact HasInteracted;

    public void Interacted() => HasInteracted?.Invoke();

}
