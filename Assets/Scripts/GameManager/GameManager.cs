using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;

    public Score score;
    // 구분선
    [SerializeField] private TMP_Text currentScoreTxt;
    [SerializeField] private TMP_Text highScoreTxt;

    private int currentScore = 0;
    private int highScore = 0;
    private string hs = "HighScore";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        UpdateTextUI();
    }

    private void Update()
    {
        SetHighScore();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
    }
    public void LoadMainMenu()
    {
        string mainMenuSceneName = "StartScene";
        Debug.Log("Loading Main Menu Scene: " + mainMenuSceneName);
        SceneManager.LoadScene(mainMenuSceneName);
    }
    public void OnMainMenuButtonClick()
    {
        LoadMainMenu();
    }

    public void GetScore(int value)
    {
        score.UpdateScoreText(value);
    }
    // 구분선
    public void AddScore(int score)
    {
        currentScore += score;
        Debug.Log(score);
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
        UpdateTextUI();
    }

    private void UpdateTextUI()
    {
        currentScoreTxt.text = $"Score : {currentScore}";
        highScoreTxt.text = $"High Score : {highScore}";
    }

    private void SetHighScore()
    {
        if (PlayerPrefs.HasKey(hs))
        {
            float highScore = PlayerPrefs.GetFloat(hs);
            if (highScore < currentScore)
            {
                PlayerPrefs.SetFloat(hs, currentScore);
                Debug.Log(highScore);
            }
            else
            {
                return;
            }
        }
        else
        {
            PlayerPrefs.SetFloat(hs, currentScore);
        }
    }
}
