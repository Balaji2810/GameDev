
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Score : MonoBehaviour
{

    public Text score;
    private String ConnectionString;
    private String sqlquerry;

    public void Start()
    {
        ConnectionString = "URI=file:" + Application.dataPath + "/Plugins/database.s3db";
        ResetScore();
    }

    public void ResetScore()
    {
        //score.text="0";
        SetScore(-1);
        


    }

    public void addScore(int x)
    {
        //score.text=(long.Parse(score.text)+x).ToString();
      
        SetScore(x);
        
    }


    //DB connections
    public void SetScore(int x)
    {
        if (x == -1)
        {
            ES2.Save(0, "file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=score");

            
        }
        else 
        {
            int temp=-1;
            temp = ES2.Load<int>("file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=score");
            ES2.Save(temp+x, "file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=score");
            temp = 1;

        }

        score.text= (ES2.Load<int>("file.dump?encrypt=true&encryptiontype=obfuscate&password=pass1&tag=score")).ToString();
    }
    
}
