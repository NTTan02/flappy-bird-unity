using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text finalScoreText;
    public GameObject gameOverPanel;
    public GameObject startPanel;
    
    public Text timeText;
    public Text finalTimeText;
    private float playTime = 0f;
    private bool isPlaying = false;

    void Start()
    {
        Time.timeScale = 0;
        startPanel.SetActive(true);
        gameOverPanel.SetActive(false);
        playTime = 0f;
        isPlaying = false;
    }

    void Update()
    {
        if (isPlaying)
        {
            playTime += Time.deltaTime;
            UpdateTimeText();
        }
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(playTime / 60f);
        int seconds = Mathf.FloorToInt(playTime % 60f);
        int milliseconds = Mathf.FloorToInt((playTime * 100f) % 100f);
        
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        startPanel.SetActive(false);
        score = 0;
        playTime = 0f;
        isPlaying = true;
        scoreText.text = score.ToString();
        timeText.text = "00:00:00";
    }

    public void AddScore(int points = 1)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        isPlaying = false;
        gameOverPanel.SetActive(true);
        finalScoreText.text = "Score : " + score.ToString();
        
        int minutes = Mathf.FloorToInt(playTime / 60f);
        int seconds = Mathf.FloorToInt(playTime % 60f);
        int milliseconds = Mathf.FloorToInt((playTime * 100f) % 100f);
        finalTimeText.text = "Time : " + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}