
using UnityEngine;
using UnityEngine.UI;
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
        ConnectionString = "URI=file:" + Application.dataPath + "/Plugins/sql.db";
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
        using (IDbConnection Dbconn = new SqliteConnection(ConnectionString))
        {
            Dbconn.Open();

            using (IDbCommand DbCmd = Dbconn.CreateCommand())
            {

                if (x > 0)
                {
                    sqlquerry = "select * from data";
                    DbCmd.CommandText = sqlquerry;
                    
                    using (IDataReader reader1 = DbCmd.ExecuteReader())
                    {
                        int temp = -1;
                        while (reader1.Read())
                        {
                            temp=reader1.GetInt32(3);
                            print(reader1.GetInt32(0));
                            

                        }

                        reader1.Close();
                        sqlquerry = "update data set temp=" + (temp + x) ;
                        print(sqlquerry);
                        print(DbCmd.ExecuteNonQuery());
                        temp = -1;

                    }

                }
                else
                {
                    sqlquerry = "update data set temp=0";
                    DbCmd.ExecuteNonQuery();


                }
                
                
                
                //set score
                sqlquerry = "select * from data";
                DbCmd.CommandText = sqlquerry;
                using (IDataReader reader = DbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetInt32(3)+" check");
                        score.text = (reader.GetInt32(3)).ToString();

                    }

                    reader.Close();
                    
                }

            }

            Dbconn.Close();
        }
    }
    
}
