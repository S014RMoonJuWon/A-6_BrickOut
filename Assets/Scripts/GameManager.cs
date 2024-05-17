using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    void Update()
    {

    }
}
