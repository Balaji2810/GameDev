using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
   public Transform player;
   public Vector3 offset;
   public controls StopCamera;

    // Update is called once per frame
    void Update()
    {
        if(StopCamera.Spawner)
        {
            transform.position=new Vector3(player.position.x+offset.x,transform.position.y,player.position.z+offset.z);//player.position+offset;
        }
        
    }
}
