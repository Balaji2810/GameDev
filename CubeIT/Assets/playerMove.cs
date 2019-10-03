using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float movespeed=1000; 
    public Vector3 startposition;
    public Joystick Js;
    // Start is called before the first frame update
    void Start()
    {
        startposition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /* 
        if(Input.GetKey("d"))
        {
            rb.AddForce(movespeed*Time.deltaTime,0,0,ForceMode.VelocityChange);
        }

        if(Input.GetKey("a"))
        {
            rb.AddForce(-movespeed*Time.deltaTime,0,0,ForceMode.VelocityChange);
        }

        if(Input.GetKey("w"))
        {
            rb.AddForce(0,0,movespeed*Time.deltaTime,ForceMode.VelocityChange);
        }

        if(Input.GetKey("s"))
        {
            rb.AddForce(0,0,-movespeed*Time.deltaTime,ForceMode.VelocityChange);
        }
        */
        rb.AddForce(Js.Horizontal*movespeed*Time.deltaTime,0,0,ForceMode.VelocityChange);
        rb.AddForce(0,0,Js.Vertical*movespeed*Time.deltaTime,ForceMode.VelocityChange);

        if(transform.position.y<-15)
        {
            transform.position=startposition;

        }
    }
}
