using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Asteroid;
    public Vector3 randomPos;
    public float createWait;
    public float create;
    public float LoopWait;
    int score;
    public Text text;
    bool GameOverCon = false;
    bool playAgain = false;
    public Text GameFinish;
    public Text playAgainText;
    void Start()
    {
        
        score = 0;
        text.text = "Score =" + score;
        StartCoroutine(createAstroid());
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && playAgain) {
            SceneManager.LoadScene("level2");
        }
        
    }
    IEnumerator createAstroid() {
        yield return new WaitForSeconds(createWait);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(create);
            }
            if (GameOverCon)
            {
                playAgainText.text = "Press R Key Play Again";
                playAgain = true;
                break;
            }
            yield return new WaitForSeconds(LoopWait);
           
        }

        
    }
    public void ScoreUpper(int plusScore)
    {
        score += plusScore;
        text.text = "Score =" + score;


    }
    public void gameOver() {
        GameFinish.text = "Game OveR";
        GameOverCon = true;
        
    }
    

}
