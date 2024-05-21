using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;

    public Score score;

    public int lifeCount { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        lifeCount = 2;
      
    }

    private void Start()
    {
        SoundManager.instance.PlayBGM("main");
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        SoundManager.instance.StopBgm("main");
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
}
