using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charPosition : MonoBehaviour
{
    //public Transform camera;
    public Transform character;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        //camera.position=character.position + offset;
        transform.position=character.position + offset;
    }
}
