using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject startBtn;
    public GameObject levelBox;
    public GameObject playerNameBox;
    public GameObject loadingImages;

    public TMP_InputField inputPlayerName;

    public Animator animator;

    // 난이도
    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }
    // 난이도별 버튼 변수
    public Button easyButton;
    public Button normalButton;
    public Button hardButton;

    private void Start()
    {
        easyButton.onClick.AddListener(() => SetDifficulty(Difficulty.Easy));
        normalButton.onClick.AddListener(() => SetDifficulty(Difficulty.Normal));
        hardButton.onClick.AddListener(() => SetDifficulty(Difficulty.Hard));
    }
    public void SetDifficulty(Difficulty difficulty)
    {
        DataManager.instance.level = (int)difficulty;
        loadingImages.SetActive(true);
        while (true)
        {
            if (animator.GetCurrentAnimatorStateInfo(8).IsName("LoadAni"))
            {
                break;
            }
        }
        SceneManager.LoadScene("GameScene");
    }
    public void GameStart()
    {
        startBtn.SetActive(false);
        playerNameBox.SetActive(true);
    }
    public void OnClickNameBtn()
    {
        DataManager.instance.playerName = inputPlayerName.text;
        playerNameBox.SetActive(false);
        levelBox.SetActive(true);
    }

    public void BackBtn()
    {
        SceneManager.LoadScene("StartScene");
    }
}