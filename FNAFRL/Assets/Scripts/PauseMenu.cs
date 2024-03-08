using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{

    public GameObject menu;
    public static bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(_isPaused == false)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    public void Pause()
    {
        menu.SetActive(true);
        _isPaused = true;
        Time.timeScale = 0f;
    }
    public void UnPause()
    {
        menu.SetActive(false);
        _isPaused = false;
        Time.timeScale = 1f;
    }
}
