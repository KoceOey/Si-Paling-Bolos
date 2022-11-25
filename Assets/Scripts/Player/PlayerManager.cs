using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;

    public Text scoreText;
    public Text highScoreText;
    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;
    static public bool isStart=false;
    void Start()
    {
        gameOver=false;
        Time.timeScale = 1;
        isGameStarted = false;
        highScoreText.text=""+PlayerPrefs.GetFloat("HighScore");
    }

    void Update()
    {
        if(gameOver){
            Time.timeScale=0;
            gameOverPanel.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A)){
            isGameStarted = true;
            isStart=true;
            Destroy(startingText);
        }
        if(isStart){
            scoreCount+= pointsPerSecond * Time.deltaTime;
        }
        if(scoreCount>highScoreCount){
            highScoreCount=scoreCount;
            PlayerPrefs.SetFloat("HighScore",Mathf.Round(highScoreCount));
        }
        PlayerPrefs.Save();
        scoreText.text=""+Mathf.Round(scoreCount);
        UpdateHighScore();
    }
    void UpdateHighScore(){
        highScoreText.text=""+PlayerPrefs.GetFloat("HighScore");
        highScoreCount=PlayerPrefs.GetFloat("HighScore");
    }
}
