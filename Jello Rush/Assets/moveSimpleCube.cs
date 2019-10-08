﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveSimpleCube : MonoBehaviour
{
    private float moveSpeed = 50f;
    public GameObject go;
    //public controls stopMove;
    // Start is called before the first frame update
    private bool state;

    
    void Start()
    {
        state=true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity=new Vector3(0,0,-1)*50*moveSpeed*Time.deltaTime;
        if(state)
        {
            //transform.position= new Vector3(transform.position.x,transform.position.y,transform.position.z-0.5f);
            go.GetComponent<Rigidbody>().velocity=new Vector3(0,0,-1)*100*moveSpeed*Time.deltaTime;
        }

        if(go.GetComponent<Rigidbody>().position.z<(-150) || go.GetComponent<Rigidbody>().position.y <-100 )
        {
            Destroy(go);
        }

        
        
    }

     void OnCollisionEnter(Collision colInfo)
    {
        if(colInfo.collider.name=="Cube" || colInfo.collider.name=="EndGameCube(Clone)" )//|| (stopMove.Spawner==false))
        {
            state=true;
            moveSpeed=8;
           //print("Check!!!!!!!!!!!!!!! "+colInfo.collider.name);
            
            //float x=Random.Range(-1,1),y=Random.Range(-1.0f,1.0f),z=Random.Range(-1.0f,1.0f);
            //go.GetComponent<Rigidbody>().velocity=new Vector3(x,y,-1)*50*moveSpeed*Time.deltaTime;
        }

       if(colInfo.collider.name=="BigBlock")
       {
           Destroy(go);
       }
    }
}