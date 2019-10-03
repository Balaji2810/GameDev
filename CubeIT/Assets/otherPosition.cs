using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 position;
    public Rigidbody rb;
    void Start()
    {
        position=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y>15 || transform.position.y<-15)
        {
           transform.position = position;
           rb.angularVelocity = Vector3.zero; 
        }
    }
}
