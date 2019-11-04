using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Loading : MonoBehaviour
{
    public GameObject high, highscore, current, currentscore,restart,home,video;
    public RectTransform vid, res;
    public Text cscore, hscore;
    public void loadhigh()
    {
        int h=0,cs= ES2.Load<int>("file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=score");
        if (ES2.Exists("file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=highscore"))
        {
            h = ES2.Load<int>("file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=highscore");
            
        }
        hscore.text = h.ToString();
        if (h < cs)
        {
            ES2.Save(cs, "file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=highscore");
            hscore.text = cs.ToString();
        }

        high.SetActive(true);
        highscore.SetActive(true);
    }

    public void loadcurrent()
    {
        cscore.text = (ES2.Load<int>("file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=score")).ToString();
        current.SetActive(true);
        currentscore.SetActive(true);
        
    }


    public void loadothers()
    {


        

        if ((Random.Range(0, 100)&1)==1)
        {
            StartCoroutine(do3());
            res.anchoredPosition = new Vector3(0, -350, 0);
            restart.SetActive(true);
            Invoke("do1", 2);
            

        }
        else
        {

            StartCoroutine(do3());
            vid.anchoredPosition = new Vector3(0, -350, 0);
            video.SetActive(true);
            Invoke("do2",2);
            



        }
        StartCoroutine(do3());
        StartCoroutine(do3());
        home.SetActive(true);

    }

    public void do1()
    {
        vid.anchoredPosition = new Vector3(0, -450, 0);
        video.SetActive(true);
    }

    public void do2()
    {
        res.anchoredPosition = new Vector3(0, -450, 0);
        restart.SetActive(true);
    }

    IEnumerator do3()
    {
        yield return new WaitForSeconds(3);

    }
}
