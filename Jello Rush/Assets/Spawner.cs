using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject simpleCube;
    public float TimeBetweenWaves=4f;
    public float Time2Spawn=2f;
    public controls doSpawn;


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
        switch (0)
         {
             case 0:
                float r = Random.Range(-7.5f,7.5f);
                Vector3 v= new Vector3(r,3f,390);
                Instantiate(simpleCube,v,Quaternion.identity);
                break;

         }
    }
}
