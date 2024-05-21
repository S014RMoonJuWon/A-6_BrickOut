using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    int lifeCount;
    public GameObject lifeIconPrefab; 
    public Transform gridLayoutGroup;

    private void Start()
    {
        lifeCount = GameManager.Instance.lifeCount;
        UpdateLives(lifeCount);
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
        if (lifeCount > 0)
        {
            lifeCount--;
            UpdateLives(lifeCount);
        }
    }

    public void GainLife()
    {
        lifeCount++;
        UpdateLives(lifeCount);
    }
    
}
