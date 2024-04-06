using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
[SerializeField]
private LayerMask mask;
public Camera cam;
public Light flashlight;
public Interactable interactWith;
public GameObject camHolder;
public Rigidbody rb;
public float speed, sensitivity, maxForce;
private Vector2 move, look;
private float lookRotation;
[SerializeField]
private float distance = 3f;
private bool flashlightOn;
private bool _isSprinting;
public Animator flashlightAnim;
private float _stamina = 100f;
private bool _isMoving;
public Image StaminaBar;
public Canvas staminaCanvas;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }




    public void OnMove(InputAction.CallbackContext context)
    {
        if(PauseMenu._isPaused == false)
        {
            move = context.ReadValue<Vector2>();
        }
    }
       
    public void OnLook(InputAction.CallbackContext context)
    {
        if(PauseMenu._isPaused == false)
        {
            look = context.ReadValue<Vector2>();
       }
    }
    public void Interact(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(PauseMenu._isPaused == false)
            {
                PlayerInteract();
            }
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {
        if(context.performed && _stamina > 0f)
        {
            if(PauseMenu._isPaused == false)
            {
                _isSprinting = true;
            }
        }
        else if (_stamina > 0f)
        {
            if(PauseMenu._isPaused == false)
            {
                _isSprinting = false;
            }
        }
    }

    public void FlashLight(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(PauseMenu._isPaused == false && FlashlightPickup.pickedup)
            {
                flashlightOn = !flashlightOn;
            }
        }
    }

    private void FixedUpdate()
    {
        flashlight.enabled = flashlightOn;

        flashlightAnim.SetBool("Active?" ,flashlightOn);

        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0, move.y);
        targetVelocity *= speed;

        targetVelocity = transform.TransformDirection(targetVelocity);

        Vector3 velocityChange = (targetVelocity - currentVelocity);

        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);

        StaminaBar.fillAmount = _stamina / 100f;

        if(_stamina > 99f)
        {
            staminaCanvas.enabled = false;
        }
        else
        {
            staminaCanvas.enabled = true;
        }

        if (_isSprinting)
        {
            speed = 20f;
            _stamina -= 1f;
        }
        else
        {
            speed = 10f;
            if(_stamina < 100f)
            {
                _stamina += 2f;
            }
        }
        if (_stamina < 1f)
        {
            _isSprinting = false;
        }
    }

    void LateUpdate()
    {
        if(PauseMenu._isPaused == false)
        {
        transform.Rotate(Vector3.up * look.x * sensitivity);
        lookRotation += (-look.y * sensitivity);
        lookRotation = Mathf.Clamp(lookRotation, -90, 90);
        camHolder.transform.eulerAngles = new Vector3(lookRotation, camHolder.transform.eulerAngles.y, camHolder.transform.eulerAngles.z);
        }
    }

    public void PlayerInteract()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactScript = hitInfo.transform.GetComponent<Interactable>();
            if(interactScript) interactScript.CallInteract(this);
        }
    }
}
