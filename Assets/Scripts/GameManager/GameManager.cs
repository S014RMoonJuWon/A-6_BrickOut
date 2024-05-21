using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverPanel;

    public MakeBrick makeBrick;

    public Score score;
    public Result result;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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
        RemoveRandomBrick();
        Debug.Log(makeBrick.brickList.Count);
        if (makeBrick.brickList.Count == 0) result.Winner();
    }
    private void RemoveRandomBrick()
    {
        if (makeBrick.brickList != null)
        {
            int num = Random.Range(0, makeBrick.brickList.Count);
            makeBrick.brickList.RemoveAt(num);
        }
    }
}
