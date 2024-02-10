using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed = 5.0F;
    private float Hinput;
    private float Finput;
    private float x;
    private float y;
    public float sensitivity = -1f;
    private Vector3 rotate;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}
