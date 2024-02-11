using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    private float speed = 5.0F;
    private float Hinput;
    private float Finput;
    private float x;
    private float y;
    public float sensitivity = -1f;
    private float stamina = 99f;
    private float drainspeed = 20f;
    private float increasespeed = 30f;
    private Vector3 rotate;
    private bool isSprinting;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(stamina);

         if(stamina <= 100f && isSprinting == false)
        {
            stamina += Time.deltaTime * increasespeed;
        }

        if(stamina >= 0f && isSprinting)
        {
             stamina -= Time.deltaTime * drainspeed;
        }

        // player input
        Hinput = Input.GetAxis("Horizontal");
        Finput = Input.GetAxis("Vertical");

        // move the player
        transform.Translate(Vector3.forward * Time.deltaTime * speed * Finput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * Hinput);

        // rotate the player
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        rotate = new Vector3(x,y * sensitivity, 0);
        transform.eulerAngles = transform.eulerAngles - rotate;

        // sprinting
        if(Input.GetKeyDown(KeyCode.LeftShift) && isSprinting == false)
        {
            speed = 10f;
            isSprinting = true;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5f;
            isSprinting = false;

        }
        if(stamina <= 0f)
        {
            isSprinting = false;
            speed = 5f;
        }

    }
}
