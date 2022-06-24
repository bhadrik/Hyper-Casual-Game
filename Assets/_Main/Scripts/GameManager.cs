using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] GameObject ring;
    [SerializeField] float timeToDestroy;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI secondScoreText;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject startButton;

    public int score;


    private void Awake() {
        if(Instance == null){
            Instance = this;
        }
        else{
            Destroy(this);
        }

        Time.timeScale = 0;
    }

    private void Start() {
        score = 0;
        InvokeRepeating(nameof(InstantiateRingRandom), 0, 3);
        scoreText.text = "Score: 0";
        secondScoreText.text = "Score: 0";
        gameOverPanel.SetActive(false);
    }

    void InstantiateRingRandom(){
        Vector2 pos = new Vector2(Random.Range(9.5f, 14f), Random.Range(-4f, 4f));

        var obj = Instantiate(ring, pos, Quaternion.identity);
    }


    public void ScoreIncrease(){
        score++;
        scoreText.text = "Score: " + score;
        secondScoreText.text = "Score: " + score;
    }

    public void RestartGame(){
        SceneManager.LoadSceneAsync(0);
    }

    public void GameOver(){
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame(){
        Time.timeScale = 1;
        startButton.SetActive(false);
    }
}
