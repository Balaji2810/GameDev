
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text score;

    public void ResetScore()
    {
        score.text="0";
    }

    public void addScore(int x)
    {
        score.text=(long.Parse(score.text)+x).ToString();
    }
    
}
