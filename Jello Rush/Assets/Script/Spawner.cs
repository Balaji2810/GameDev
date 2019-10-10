using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject simpleCube,fullCuboid,smartcube,smartjumpcube;
    public float TimeBetweenWaves=8f;
    public float Time2Spawn=2f;
    public controls doSpawn;
    public Transform player;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time>Time2Spawn && doSpawn.Spawner )
        {
            Spawn();
            Time2Spawn=Time.time+TimeBetweenWaves;
        }
         
    }

    void Spawn()
    {
        Vector3 v;
        float r;
        switch (Random.Range(0,4))
         {
            case 0:
                r = Random.Range(-7.5f,7.5f);
                v= new Vector3(r,3f,390);
                Instantiate(simpleCube,v,Quaternion.identity);
                break;
            case 1:
                v= new Vector3(0,3f,390);
                Instantiate(fullCuboid,v,Quaternion.identity);
                break;
            case 2:
                v= new Vector3(0,3f,390);
                Instantiate(smartcube,v,Quaternion.identity);
                break;
            case 3:
                r = Random.Range(-7.5f,7.5f);
                v= new Vector3(r,3f,390);
                Instantiate(smartjumpcube,v,Quaternion.identity);
                break;
            

         }
    }

    
}
