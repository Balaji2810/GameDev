
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class Score : MonoBehaviour
{

    public Text score;
    private String ConnectionString;

    public void Start()
    {
        ConnectionString = "URI=file:" + Application.dataPath + "/Plugins/sql.db";
    }

    public void ResetScore()
    {
        score.text="0";
        

    }

    public void addScore(int x)
    {
        score.text=(long.Parse(score.text)+x).ToString();
      
        setScore(1);
        
    }

    public void setScore(int x)
    {
        using (IDbConnection Dbconn = new SqliteConnection(ConnectionString))
        {
            Dbconn.Open();

            using (IDbCommand DbCmd = Dbconn.CreateCommand())
            {
                String sqlquerry = "select * from data";

                DbCmd.CommandText = sqlquerry;

                using (IDataReader reader = DbCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.Log(reader.GetInt32(0));
                    }

                    reader.Close();
                    Dbconn.Close();
                }

            }
        }
    }
    
}
