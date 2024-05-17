using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;

    public int score { get; set; }

    private void Awake()
    {
        score = 0;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoreTxt.text = $"Score : {score}";
    }
}
