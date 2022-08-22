using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button resGame;
    public bool isGameActive;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }

    }
    public void updateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score : " + score;

    }
    public void GameOver()
    {

        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        resGame.gameObject.SetActive(true);


    }
    public void restartGame()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }


    public void StartGame(int diffuculty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /=  diffuculty;
        StartCoroutine(SpawnTarget());
        updateScore(0);
        titleScreen.gameObject.SetActive(false);

    }
}
