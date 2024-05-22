using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    public GameObject lifeIconPrefab; 
    public Transform gridLayoutGroup;

    private void Start()
    {
        UpdateLives(GameManager.Instance.lifeCount);
    }

    public void UpdateLives(int life)
    {
        foreach (Transform childe in gridLayoutGroup)
        {
            Destroy(childe.gameObject);
        }

        for (int i = 0; i < life; i++)
        {
            Instantiate(lifeIconPrefab, gridLayoutGroup);
        }
    }

    public void LoseLife()
    {
        if (GameManager.Instance.lifeCount > 0)
        {
            GameManager.Instance.lifeCount--;
            UpdateLives(GameManager.Instance.lifeCount);
        }
    }

    public void GainLife()
    {
        GameManager.Instance.lifeCount++;
        UpdateLives(GameManager.Instance.lifeCount);
    }
}
