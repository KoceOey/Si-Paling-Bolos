using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;

    void Start()
    {
        gameOver=false;
        Time.timeScale = 1;
        isGameStarted = false;
    }

    void Update()
    {
        if(gameOver){
            Time.timeScale=0;
            gameOverPanel.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A)){
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
