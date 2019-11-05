using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class changecolor : MonoBehaviour
{
    public Material mtrl;
    Color c1 = Color.red;
    Color c2 = Color.green;
    Color c3 = Color.blue;
    Color c4 = Color.yellow;
    Color c5 = Color.cyan;
    Color c6 = Color.magenta;
    public float duration = 0.50f;
    float lerp;
    public float delay;
    int wait;
    // Start is called before the first frame update
    void Start()
    {
        
        
        mtrl.color = c1;
        wait = 6;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (wait == 6)
        {
            lerp = Mathf.PingPong(Time.time, duration) / duration;
            wait--;
            Invoke("C1", delay);
            wait--;
            Invoke("C2", delay * 2);
            wait--;
            Invoke("C3", delay * 3);
            wait--;
            Invoke("C4", delay * 4);
            wait--;
            Invoke("C5", delay * 5);
            wait--;
            Invoke("C6", delay * 6);
        }











    }


    public void C1()
    {
        mtrl.color = Color.Lerp(c6, c1, lerp);
        wait++;
    }

    public void C2()
    {
        mtrl.color = Color.Lerp(c1, c2, lerp);
        wait++;
    }
    public void C3()
    {
        mtrl.color = Color.Lerp(c2, c3, lerp);
        wait++;
    }
    public void C4()
    {
        mtrl.color = Color.Lerp(c3, c4, lerp);
        wait++;
    }
    public void C5()
    {
        mtrl.color = Color.Lerp(c4, c5, lerp);
        wait++;
    }
    public void C6()
    {
        mtrl.color = Color.Lerp(c5, c6, lerp);
        wait++;
    }

    
}
