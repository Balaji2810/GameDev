using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Score score;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // StartCoroutine(Example());
       // score.addScore(1000);

    }


    IEnumerator Example()
    {
        print(Time.time);
        yield return new WaitForSeconds(10);
        print(Time.time);
    }
}
