using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanToggle : MonoBehaviour
{


    public Interactable toggle;
    public Animator fanAnim;

    private bool _isOn = true;

    private void OnEnable()
    {
        if(toggle)
        {
            toggle.GetInteractEvent.HasInteracted += ToggleFan;
        }
    }

    private void OnDisable()
    {
        if(toggle)
        {
            toggle.GetInteractEvent.HasInteracted -= ToggleFan;
        }
    }


    public void ToggleFan()
    {
        _isOn = !_isOn;
    }

    private void FixedUpdate()
    {
        fanAnim.SetBool("isOn?", _isOn);
    }

}
