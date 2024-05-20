using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMP_Text scoreTxt;

    private int score = 0;

    private void Awake()
    {
        if (scoreTxt == null)
        {
            Debug.LogError("Score Text is not assigned in the inspector.");
        }
    }

    public void UpdateScoreText(int value)
    {
        Debug.Log(scoreTxt.text);
        score += value;
        Debug.Log(score);
        scoreTxt.text = $"Score : {score}";
    }
    private void Update()
    {

    }
}
