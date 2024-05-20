using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
