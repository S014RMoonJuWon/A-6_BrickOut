using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{
    public TMP_Text scoreTxt;

    private int score = 0;

    public void UpdateScoreText(int value)
    {
        score += value;
        scoreTxt.text = $"Score :{score}";
    }
}
