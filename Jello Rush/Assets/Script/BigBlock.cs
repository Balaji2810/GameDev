﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBlock : MonoBehaviour
{
    public Score score;
    public controls StopScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.name == "simple cube(Clone)" && StopScore.Spawner)
        {
            score.addScore(1);
            //print(colInfo.collider.name);
        }
        else if (colInfo.collider.name == "FullCuboid(Clone)" && StopScore.Spawner)
        {
            score.addScore(2);
            //print(colInfo.collider.name);
        }
        else if (colInfo.collider.name == "SmartCube(Clone)" && StopScore.Spawner)
        {
            score.addScore(4);
            //print(colInfo.collider.name);
        }
        else if (colInfo.collider.name == "SmartJumpCube(Clone)" && StopScore.Spawner)
        {
            score.addScore(4);
            //print(colInfo.collider.name);
        }

        else if (colInfo.collider.name == "simpleCuboid(Clone)" && StopScore.Spawner)
        {
            score.addScore(2);
            //print(colInfo.collider.name);
        }
        else if (colInfo.collider.name == "smallpathCube(Clone)" && StopScore.Spawner)
        {
            score.addScore(3);
            //print(colInfo.collider.name);
        }
        else if ((colInfo.collider.name == "smallwallCube(Clone)" && StopScore.Spawner))
        {
            score.addScore(2);
        }
        
    }
}
