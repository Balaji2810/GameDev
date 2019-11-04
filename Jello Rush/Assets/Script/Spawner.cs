using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject simpleCube,fullCuboid,smartcube,smartjumpcube,simpleCuboid,smallpathCube;
    public float TimeBetweenWaves=10f;
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
        GameObject t;
        switch (Random.Range(0,5))
         {
            case 0:
                r = Random.Range(-8f,8.00000000000000001f);
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
                r = Random.Range(-8f, 8.00000000000000001f);
                v = new Vector3(r,3f,390);
                Instantiate(smartjumpcube,v,Quaternion.identity);
                break;
            case 4:
                if(Random.Range(0,2)==1)
                {
                    r = Random.Range(-8f, 8.00000000000000001f);
                    v = new Vector3(r,3f,390);
                    t=Instantiate(simpleCuboid,v,Quaternion.identity);
                    t.transform.rotation =  Quaternion.Euler(0, 0, 90);
                }
                else
                {
                    r = Random.Range(-6f,6.0000000000000000001f);
                    v= new Vector3(r,3f,390);
                    t=Instantiate(simpleCuboid,v,Quaternion.identity);
                    t.transform.rotation =  Quaternion.Euler(90, 0, 0);
                }
                
                break;
            case 5:
                r = Random.Range(2.0f,18.0f);
                


                v= new Vector3(((0+r)/2)-10,3f,390);
                t=Instantiate(smallpathCube,v,Quaternion.identity);
                t.transform.localScale=new Vector3(r,8,2);

                v= new Vector3(((r+1.9f+20)/2)-10,3f,390);
                t=Instantiate(smallpathCube,v,Quaternion.identity);
                t.transform.localScale=new Vector3(20-(r+1.9f),8,2);
                break;


            

         }
    }

    
}
