using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Score score;
    public controls GameEnd;
    public GameObject EndGameUI;

    public void Start()
    {
        // score.ResetScore();
        
    }
    public void Restart()
    {
        score.ResetScore();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //score.SetScore(1000);
        StartCoroutine(Example());
       // score.addScore(1000);

    }
    public void GameOver()
    {

        EndGameUI.SetActive(true);

    }

    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
    }
}
