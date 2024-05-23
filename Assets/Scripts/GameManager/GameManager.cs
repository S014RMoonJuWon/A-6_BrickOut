using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public MakeBrick makeBrick;
    public Result result;

    public GameObject EndPanel;
    public GameObject homeBtn;
    public GameObject retryBtn;
    public GameObject nextStageBtn;

    [SerializeField] private TMP_Text currentScoreTxt;
    [SerializeField] private TMP_Text endScoreTxt;
    [SerializeField] private TMP_Text highScoreTxt;
    [SerializeField] private TMP_Text secondScoreTxt;
    [SerializeField] private TMP_Text thirdScoreTxt;
    [SerializeField] private TMP_Text HighScorePlayer;
    [SerializeField] private TMP_Text SecondScorePlayer;
    [SerializeField] private TMP_Text ThirdScorePlayer;

    private int currentScore = 0;
    private int highScore = 0;
    private int secondScore = 0;
    private int thirdScore = 0;

    private string highScorePlayer = "";
    private string secondScorePlayer = "";
    private string thirdScorePlayer = "";

    public int lifeCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }   
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        lifeCount = 3;
        currentScore = DataManager.instance.saveScoreData;
        currentScoreTxt.text = "Score :" + currentScore;
    }

    private void Start()
    {
        SoundManager.instance.PlayBGM("main");
        LoadHighScore();
        UpdateTextUI();
    }

    public void GameOver()
    {
        SoundManager.instance.StopBgm("main");
        EndPanel.SetActive(true);
        nextStageBtn.SetActive(false);
        UpdateHighScores();
        UpdateTextUI();
    }
    public void OnRetryButtonClick()
    {
        DataManager.instance.saveScoreData = 0;
        SceneManager.LoadScene(1);
    }
    public void OnMainMenuButtonClick()
    {
        DataManager.instance.saveScoreData = 0;
        DataManager.instance.stageCount = 0;
        SceneManager.LoadScene(0);
    }
    public void OnNextStageBtn()
    {
        DataManager.instance.stageCount++;
        SceneManager.LoadScene(1);
    }

    public void GetScore(int value)
    {
        currentScore += value;
        currentScoreTxt.text = $"Score : {currentScore}";
        RemoveRandomBrick();

        Debug.Log(makeBrick.brickList.Count);
        if (makeBrick.brickList.Count == 0) result.Winner();
    }
    public void RemoveRandomBrick()
    {
        if (makeBrick.brickList != null)
        {
            int num = Random.Range(0, makeBrick.brickList.Count);
            makeBrick.brickList.RemoveAt(num);
        }
    }

    public void UpdateHighScores()
    {
        if (currentScore > highScore)
        {
            thirdScore = secondScore;
            thirdScorePlayer = secondScorePlayer;

            secondScore = highScore;
            secondScorePlayer = highScorePlayer;

            highScore = currentScore;
            highScorePlayer = DataManager.instance.playerName;
        }
        else if (currentScore > secondScore)
        {
            thirdScore = secondScore;
            thirdScorePlayer = secondScorePlayer;

            secondScore = currentScore;
            secondScorePlayer = DataManager.instance.playerName;
        }
        else if (currentScore > thirdScore)
        {
            thirdScore = currentScore;
            thirdScorePlayer = DataManager.instance.playerName;
        }
        DataManager.instance.saveScoreData =  currentScore;
        SaveHighScore();
    }
    public void UpdateTextUI()
    {
        currentScoreTxt.text = $"Score : {currentScore}";
        endScoreTxt.text = $"{currentScore}";
        highScoreTxt.text = $"{highScore}";
        secondScoreTxt.text = $"{secondScore}";
        thirdScoreTxt.text = $"{thirdScore}";
        HighScorePlayer.text = highScorePlayer;
        SecondScorePlayer.text = secondScorePlayer;
        ThirdScorePlayer.text = thirdScorePlayer;
    }

    private void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        secondScore = PlayerPrefs.GetInt("SecondScore", 0);
        thirdScore = PlayerPrefs.GetInt("ThirdScore", 0);
        highScorePlayer = PlayerPrefs.GetString("HighScorePlayer", "");
        secondScorePlayer = PlayerPrefs.GetString("SecondScorePlayer", "");
        thirdScorePlayer = PlayerPrefs.GetString("ThirdScorePlayer", "");
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.SetInt("SecondScore", secondScore);
        PlayerPrefs.SetInt("ThirdScore", thirdScore);
        PlayerPrefs.SetString("HighScorePlayer", highScorePlayer);
        PlayerPrefs.SetString("SecondScorePlayer", secondScorePlayer);
        PlayerPrefs.SetString("ThirdScorePlayer", thirdScorePlayer);
        PlayerPrefs.Save();
    }
}